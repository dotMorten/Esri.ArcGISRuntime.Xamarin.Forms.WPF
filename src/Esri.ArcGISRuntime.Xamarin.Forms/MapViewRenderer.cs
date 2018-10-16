using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.UI.Controls;
using Xamarin.Forms.Platform.WPF;

[assembly: ExportRenderer(typeof(Esri.ArcGISRuntime.Xamarin.Forms.MapView), typeof(Esri.ArcGISRuntime.Xamarin.Forms.MapViewRenderer))]

namespace Esri.ArcGISRuntime.Xamarin.Forms
{
    public class MapViewRenderer : GeoViewRenderer<Esri.ArcGISRuntime.Xamarin.Forms.MapView, Esri.ArcGISRuntime.UI.Controls.MapView>
    {
        public MapViewRenderer()
        {

        }

        internal override UI.Controls.MapView CreateNativeControl()
        {
            return new UI.Controls.MapView();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MapView> e)
        {
            base.OnElementChanged(e);
            Control.Map = Element.Map;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(MapView.Map))
            {
                Control.Map = Element.Map;
            }
        }

        bool _isDisposed;

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                if (Control != null)
                {
                }
            }
            _isDisposed = true;
            base.Dispose(disposing);
        }
    }
}
