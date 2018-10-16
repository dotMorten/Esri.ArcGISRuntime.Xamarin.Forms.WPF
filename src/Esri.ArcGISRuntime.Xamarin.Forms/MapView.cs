using Esri.ArcGISRuntime.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Esri.ArcGISRuntime.Xamarin.Forms
{
    [RenderWith(typeof(MapViewRenderer))]
    [ContentProperty(nameof(Map))]
    public class MapView : GeoView
    {
        public MapView() : base()
        {
        }

        /// <summary>
        /// Identifies the <see cref="Map"/> bindable property.
        /// </summary>
        public static readonly BindableProperty MapProperty =
            BindableProperty.Create("Map", typeof(Map), typeof(MapView), null, BindingMode.OneWay, null, null);

        /// <summary>
        /// Gets or sets the map the view is rendering.
        /// </summary>
        /// <value>The map the view renders.</value>
        //[TypeConverter(typeof(MapConverter))]
        public Map Map
        {
            get { return (Map)GetValue(MapProperty); }
            set { SetValue(MapProperty, value); }
        }
    }
}