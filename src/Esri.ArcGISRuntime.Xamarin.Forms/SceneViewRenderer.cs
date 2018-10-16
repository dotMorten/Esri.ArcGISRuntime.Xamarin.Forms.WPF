using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.UI.Controls;
using Xamarin.Forms.Platform.WPF;

[assembly: ExportRenderer(typeof(Esri.ArcGISRuntime.Xamarin.Forms.SceneView), typeof(Esri.ArcGISRuntime.Xamarin.Forms.SceneViewRenderer))]

namespace Esri.ArcGISRuntime.Xamarin.Forms
{
    public class SceneViewRenderer : GeoViewRenderer<Esri.ArcGISRuntime.Xamarin.Forms.SceneView, Esri.ArcGISRuntime.UI.Controls.SceneView>
    {
        public SceneViewRenderer()
        {

        }

        internal override UI.Controls.SceneView CreateNativeControl()
        {
            return new UI.Controls.SceneView();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SceneView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                SetNativeControl(new UI.Controls.SceneView());
                Control.Scene = Element.Scene;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(SceneView.Scene))
            {
                Control.Scene = Element.Scene;
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
