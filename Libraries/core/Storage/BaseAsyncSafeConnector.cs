﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDS.RDF.Storage
{
    public abstract class BaseAsyncSafeConnector
        : IStorageProvider, IAsyncStorageProvider
    {
        public abstract void LoadGraph(IGraph g, Uri graphUri);

        public abstract void LoadGraph(IGraph g, string graphUri);

        public abstract void LoadGraph(IRdfHandler handler, Uri graphUri);

        public abstract void LoadGraph(IRdfHandler handler, string graphUri);

        public abstract void SaveGraph(IGraph g);

        public abstract void UpdateGraph(Uri graphUri, IEnumerable<Triple> additions, IEnumerable<Triple> removals);

        public abstract void UpdateGraph(string graphUri, IEnumerable<Triple> additions, IEnumerable<Triple> removals);

        public abstract void DeleteGraph(Uri graphUri);

        public abstract void DeleteGraph(string graphUri);

        public abstract IEnumerable<Uri> ListGraphs();

        public abstract bool IsReady
        {
            get;
        }

        public abstract bool IsReadOnly
        {
            get;
        }

        public abstract IOBehaviour IOBehaviour
        {
            get;
        }

        public abstract bool UpdateSupported
        {
            get;
        }

        public abstract bool DeleteSupported
        {
            get;
        }

        public abstract bool ListGraphsSupported
        {
            get;
        }

        public abstract void Dispose();

        public void LoadGraph(IGraph g, Uri graphUri, LoadGraphCallback callback, object state)
        {
            this.AsyncLoadGraph(g, graphUri, callback, state);
        }

        public void LoadGraph(IGraph g, string graphUri, LoadGraphCallback callback, object state)
        {
            Uri u = (String.IsNullOrEmpty(graphUri) ? null : UriFactory.Create(graphUri));
            this.LoadGraph(g, u, callback, state);
        }

        public void LoadGraph(IRdfHandler handler, Uri graphUri, LoadHandlerCallback callback, object state)
        {
            this.AsyncLoadGraph(handler, graphUri, callback, state);
        }

        public void LoadGraph(IRdfHandler handler, string graphUri, LoadHandlerCallback callback, object state)
        {
            Uri u = (String.IsNullOrEmpty(graphUri) ? null : UriFactory.Create(graphUri));
            this.LoadGraph(handler, u, callback, state);
        }

        public void SaveGraph(IGraph g, SaveGraphCallback callback, object state)
        {
            this.AsyncSaveGraph(g, callback, state);
        }

        public void UpdateGraph(Uri graphUri, IEnumerable<Triple> additions, IEnumerable<Triple> removals, UpdateGraphCallback callback, object state)
        {
            this.AsyncUpdateGraph(graphUri, additions, removals, callback, state);
        }

        public void UpdateGraph(string graphUri, IEnumerable<Triple> additions, IEnumerable<Triple> removals, UpdateGraphCallback callback, object state)
        {
            Uri u = (String.IsNullOrEmpty(graphUri) ? null : UriFactory.Create(graphUri));
            this.UpdateGraph(u, additions, removals, callback, state);
        }

        public void DeleteGraph(Uri graphUri, DeleteGraphCallback callback, object state)
        {
            this.AsyncDeleteGraph(graphUri, callback, state);
        }

        public void DeleteGraph(string graphUri, DeleteGraphCallback callback, object state)
        {
            Uri u = (String.IsNullOrEmpty(graphUri) ? null : UriFactory.Create(graphUri));
            this.DeleteGraph(u, callback, state);
        }

        public void ListGraphs(ListGraphsCallback callback, object state)
        {
            this.AsyncListGraphs(callback, state);
        }
    }
}