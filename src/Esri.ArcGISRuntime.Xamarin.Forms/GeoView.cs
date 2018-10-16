using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

//[assembly: ExportRenderer(typeof(Esri.ArcGISRuntime.Xamarin.Forms.GeoView), typeof(Esri.ArcGISRuntime.Xamarin.Forms.GeoViewRenderer))]

namespace Esri.ArcGISRuntime.Xamarin.Forms
{
    public abstract partial class GeoView : global::Xamarin.Forms.View, INotifyPropertyChanged
    {
        internal Esri.ArcGISRuntime.UI.Controls.GeoView NativeGeoView;

        internal GeoView()
        {
            GraphicsOverlays = new GraphicsOverlayCollection();
            //SubscribeNativeViewEvents(nativeView);
            // InitializeDependencyProperties(nativeView);
            //NativeGeoView = nativeView;
            //Esri.ArcGISRuntime.UI.Controls.GeoView
        }

        #region Dependency Properties

        public static readonly BindableProperty GraphicsOverlaysProperty =
            BindableProperty.Create(nameof(GraphicsOverlays), typeof(GraphicsOverlayCollection), typeof(GeoView), null,
                BindingMode.OneWay, null, null);

        public GraphicsOverlayCollection GraphicsOverlays
        {
            get { return (GraphicsOverlayCollection)GetValue(GraphicsOverlaysProperty); }
            set { SetValue(GraphicsOverlaysProperty, value); }
        }

        public static readonly BindableProperty IsAttributionTextVisibleProperty =
            BindableProperty.Create(nameof(IsAttributionTextVisible), typeof(bool), typeof(GeoView), true, BindingMode.OneWay,
                null, null);

        public bool IsAttributionTextVisible
        {
            get { return (bool)GetValue(IsAttributionTextVisibleProperty); }
            set { SetValue(IsAttributionTextVisibleProperty, value); }
        }

        public static readonly BindableProperty ViewInsetsProperty =
            BindableProperty.Create(nameof(ViewInsets), typeof(global::Xamarin.Forms.Thickness), typeof(GeoView), new global::Xamarin.Forms.Thickness(0), BindingMode.OneWay, null, null);

        public global::Xamarin.Forms.Thickness ViewInsets
        {
            get { return (global::Xamarin.Forms.Thickness)GetValue(ViewInsetsProperty); }
            set { SetValue(ViewInsetsProperty, value); }
        }

        public static readonly BindableProperty TimeExtentProperty =
            BindableProperty.Create(nameof(TimeExtent), typeof(TimeExtent), typeof(GeoView), null, BindingMode.OneWay,
                null, null);

        public TimeExtent TimeExtent
        {
            get { return (TimeExtent)GetValue(TimeExtentProperty); }
            set { SetValue(TimeExtentProperty, value); }
        }

        public static readonly BindableProperty SelectionPropertiesProperty =
           BindableProperty.Create(nameof(SelectionProperties), typeof(SelectionProperties), typeof(GeoView), null, BindingMode.OneWay,
               null, null);
        public SelectionProperties SelectionProperties
        {
            get { return (SelectionProperties)GetValue(SelectionPropertiesProperty); }
            set { SetValue(SelectionPropertiesProperty, value); }
        }

        #endregion

        #region Properties

        public SpatialReference SpatialReference => NativeGeoView?.SpatialReference;
        public bool IsNavigating => NativeGeoView?.IsNavigating == true;
        public bool IsWrapAroundEnabled => NativeGeoView?.IsWrapAroundEnabled == true;
        public DrawStatus DrawStatus => NativeGeoView?.DrawStatus ?? DrawStatus.Completed;

        #endregion

        #region Methods
        public Task<IReadOnlyList<IdentifyLayerResult>> IdentifyLayersAsync(Point screenPoint, double tolerance, bool returnPopupsOnly)
        {
            return NativeGeoView.IdentifyLayersAsync(new System.Windows.Point(screenPoint.X, screenPoint.Y), tolerance, returnPopupsOnly);
        }

        public void ShowCalloutForGeoElement(GeoElement element, Point tapPosition, CalloutDefinition definition)
        {
            NativeGeoView.ShowCalloutForGeoElement(element, new System.Windows.Point(tapPosition.X, tapPosition.Y), definition);
        }

        public void SetViewpoint(Viewpoint viewpoint) => NativeGeoView.SetViewpoint(viewpoint);

        public Task<bool> SetViewpointAsync(Viewpoint viewpoint) => NativeGeoView.SetViewpointAsync(viewpoint);
        #endregion

        #region Events
        public event EventHandler<DrawStatusChangedEventArgs> DrawStatusChanged;
        internal void RaiseDrawStatusChanged(DrawStatusChangedEventArgs e) => DrawStatusChanged?.Invoke(this, e);

        public event EventHandler SpatialReferenceChanged;
        internal void RaiseSpatialReferenceChanged() => SpatialReferenceChanged?.Invoke(this, EventArgs.Empty);

        public event EventHandler ViewpointChanged;
        internal void RaiseViewpointChanged() => ViewpointChanged?.Invoke(this, EventArgs.Empty);

        public event EventHandler<GeoViewInputEventArgs> GeoViewTapped;
        internal void RaiseGeoViewTapped(UI.Controls.GeoViewInputEventArgs e) => GeoViewTapped?.Invoke(this, new GeoViewInputEventArgs(e));

        public event EventHandler<GeoViewInputEventArgs> GeoViewDoubleTapped;
        internal void RaiseGeoViewDoubleTapped(UI.Controls.GeoViewInputEventArgs e) => GeoViewDoubleTapped?.Invoke(this, new GeoViewInputEventArgs(e));

        public event EventHandler<LayerViewStateChangedEventArgs> LayerViewStateChanged;
        internal void RaiseLayerViewStateChanged(LayerViewStateChangedEventArgs e) => LayerViewStateChanged?.Invoke(this, e);

        public event EventHandler<GeoViewInputEventArgs> GeoViewHolding;
        internal void RaiseGeoViewHolding(UI.Controls.GeoViewInputEventArgs e) => GeoViewHolding?.Invoke(this, new GeoViewInputEventArgs(e));

        public event EventHandler NavigationCompleted;
        internal void RaiseNavigationCompleted() => NavigationCompleted?.Invoke(this, EventArgs.Empty);

        internal void RaisePropertyChanged(string propertyName) => OnPropertyChanged(propertyName);

        #endregion
    }

}
