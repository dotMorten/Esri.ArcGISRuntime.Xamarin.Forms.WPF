using Esri.ArcGISRuntime.Geometry;
using System;

namespace Esri.ArcGISRuntime.Xamarin.Forms
{
    public sealed class GeoViewInputEventArgs : EventArgs
    {
        private Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs _args;

        internal GeoViewInputEventArgs(Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs args)
        {
            _args = args;
        }

        public global::Xamarin.Forms.Point Position => new global::Xamarin.Forms.Point(_args.Position.X, _args.Position.Y);

        public MapPoint Location => _args.Location;

        public bool Handled
        {
            get => _args.Handled;
            set => _args.Handled = value;
        }
    }
}
