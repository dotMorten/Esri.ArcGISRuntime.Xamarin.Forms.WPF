using Esri.ArcGISRuntime.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Esri.ArcGISRuntime.Xamarin.Forms
{
    [RenderWith(typeof(SceneViewRenderer))]
    [ContentProperty(nameof(Scene))]
    public class SceneView : GeoView
    {
        public SceneView() : base()
        {
        }

        public static readonly BindableProperty SceneProperty =
            BindableProperty.Create(nameof(Scene), typeof(Scene), typeof(SceneView), null, BindingMode.OneWay, null, null);

        public Scene Scene
        {
            get { return (Scene)GetValue(SceneProperty); }
            set { SetValue(SceneProperty, value); }
        }
    }
}