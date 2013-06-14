/*
dotNetRDF is free and open source software licensed under the MIT License

-----------------------------------------------------------------------------

Copyright (c) 2009-2013 dotNetRDF Project (dotnetrdf-developer@lists.sf.net)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is furnished
to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace VDS.RDF.Query.Builder.Expressions
{
    public partial class VariableExpression
    {
#pragma warning disable 1591
        public static BooleanExpression operator >(VariableExpression left, LiteralExpression right)
        {
            return Gt(left.Expression, right.Expression);
        }

        public static BooleanExpression operator <(VariableExpression left, LiteralExpression right)
        {
            return Lt(left.Expression, right.Expression);
        }

        public static BooleanExpression operator >(LiteralExpression left, VariableExpression right)
        {
            return Gt(left.Expression, right.Expression);
        }

        public static BooleanExpression operator <(LiteralExpression left, VariableExpression right)
        {
            return Lt(left.Expression, right.Expression);
        }

        public static BooleanExpression operator >=(VariableExpression left, LiteralExpression right)
        {
            return Ge(left.Expression, right.Expression);
        }

        public static BooleanExpression operator <=(VariableExpression left, LiteralExpression right)
        {
            return Le(left.Expression, right.Expression);
        }

        public static BooleanExpression operator >=(LiteralExpression left, VariableExpression right)
        {
            return Ge(left.Expression, right.Expression);
        }

        public static BooleanExpression operator <=(LiteralExpression left, VariableExpression right)
        {
            return Le(left.Expression, right.Expression);
        }
#pragma warning restore 1591
    }
}