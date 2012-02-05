﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VDS.RDF.Nodes;

namespace VDS.RDF.Query.Expressions.Comparison
{
    /// <summary>
    /// Class representing Relational Less Than or Equal To Expressions
    /// </summary>
    public class LessThanOrEqualToExpression
        : BaseBinaryExpression
    {
        private SparqlNodeComparer _comparer = new SparqlNodeComparer();

        /// <summary>
        /// Creates a new Less Than or Equal To Relational Expression
        /// </summary>
        /// <param name="leftExpr">Left Hand Expression</param>
        /// <param name="rightExpr">Right Hand Expression</param>
        public LessThanOrEqualToExpression(ISparqlExpression leftExpr, ISparqlExpression rightExpr) : base(leftExpr, rightExpr) { }

        public override IValuedNode Evaluate(SparqlEvaluationContext context, int bindingID)
        {
            IValuedNode a, b;
            a = this._leftExpr.Evaluate(context, bindingID);
            b = this._rightExpr.Evaluate(context, bindingID);

            if (a == null)
            {
                if (b == null)
                {
                    return new BooleanNode(null, true);
                }
                else
                {
                    throw new RdfQueryException("Cannot evaluate a <= when one argument is a Null");
                }
            }

            int compare = this._comparer.Compare(a, b);
            return new BooleanNode(null, compare <= 0);
        }

        /// <summary>
        /// Gets the String representation of this Expression
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            if (this._leftExpr.Type == SparqlExpressionType.BinaryOperator)
            {
                output.Append("(" + this._leftExpr.ToString() + ")");
            }
            else
            {
                output.Append(this._leftExpr.ToString());
            }
            output.Append(" <= ");
            if (this._rightExpr.Type == SparqlExpressionType.BinaryOperator)
            {
                output.Append("(" + this._rightExpr.ToString() + ")");
            }
            else
            {
                output.Append(this._rightExpr.ToString());
            }
            return output.ToString();
        }

        /// <summary>
        /// Gets the Type of the Expression
        /// </summary>
        public override SparqlExpressionType Type
        {
            get
            {
                return SparqlExpressionType.BinaryOperator;
            }
        }

        /// <summary>
        /// Gets the Functor of the Expression
        /// </summary>
        public override string Functor
        {
            get
            {
                return "<=";
            }
        }

        /// <summary>
        /// Transforms the Expression using the given Transformer
        /// </summary>
        /// <param name="transformer">Expression Transformer</param>
        /// <returns></returns>
        public override ISparqlExpression Transform(IExpressionTransformer transformer)
        {
            return new LessThanOrEqualToExpression(transformer.Transform(this._leftExpr), transformer.Transform(this._rightExpr));
        }
    }
}