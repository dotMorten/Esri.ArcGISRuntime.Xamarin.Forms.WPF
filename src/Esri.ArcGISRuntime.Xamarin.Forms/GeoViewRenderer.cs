using System;
using System.ComponentModel;
using Xamarin.Forms.Platform.WPF;

namespace Esri.ArcGISRuntime.Xamarin.Forms
{
    public abstract class GeoViewRenderer<S, T> : ViewRenderer<S, T>
        where S : Esri.ArcGISRuntime.Xamarin.Forms.GeoView
        where T : Esri.ArcGISRuntime.UI.Controls.GeoView
    {
        internal GeoViewRenderer()
        {
        }

        internal abstract T CreateNativeControl();

        protected override void OnElementChanged(ElementChangedEventArgs<S> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                SetNativeControl(CreateNativeControl());
                Element.NativeGeoView = Control;
                //Sync propertues
                Control.GraphicsOverlays = Element.GraphicsOverlays;
                Control.IsAttributionTextVisible = Element.IsAttributionTextVisible;
                UpdateViewInsets();
                Control.TimeExtent = Element.TimeExtent;
                //Connect events
                Control.DrawStatusChanged += Control_DrawStatusChanged;
                Control.SpatialReferenceChanged += Control_SpatialReferenceChanged;
                Control.ViewpointChanged += Control_ViewpointChanged;
                Control.GeoViewTapped += Control_GeoViewTapped;
                Control.GeoViewDoubleTapped += Control_GeoViewDoubleTapped;
                Control.LayerViewStateChanged += Control_LayerViewStateChanged;
                Control.GeoViewHolding += Control_GeoViewHolding;
                Control.NavigationCompleted += Control_NavigationCompleted;
                (Control as INotifyPropertyChanged).PropertyChanged += GeoViewRenderer_PropertyChanged;
            }
        }

        private void UpdateViewInsets()
        {
            var elm = Element.ViewInsets;
            Control.ViewInsets = new System.Windows.Thickness(elm.Left, elm.Top, elm.Right, elm.Bottom);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName)
            {
                case nameof(GeoView.GraphicsOverlays):
                    Control.GraphicsOverlays = Element.GraphicsOverlays; break;
                case nameof(GeoView.IsAttributionTextVisible):
                    Control.IsAttributionTextVisible = Element.IsAttributionTextVisible; break;
                case nameof(GeoView.ViewInsets):
                    UpdateViewInsets(); break;
                case nameof(GeoView.TimeExtent):
                    Control.TimeExtent = Element.TimeExtent; break;
                default: break;
            }
        }

        private void Control_DrawStatusChanged(object sender, UI.DrawStatusChangedEventArgs e) => Element.RaiseDrawStatusChanged(e);
        private void Control_LayerViewStateChanged(object sender, Mapping.LayerViewStateChangedEventArgs e) => Element.RaiseLayerViewStateChanged(e);
        private void Control_ViewpointChanged(object sender, System.EventArgs e) => Element.RaiseViewpointChanged();
        private void Control_SpatialReferenceChanged(object sender, System.EventArgs e) =>Element.RaiseSpatialReferenceChanged();
        private void Control_NavigationCompleted(object sender, EventArgs e) => Element.RaiseNavigationCompleted();
        private void Control_GeoViewTapped(object sender, UI.Controls.GeoViewInputEventArgs e) => Element.RaiseGeoViewTapped(e);
        private void Control_GeoViewHolding(object sender, UI.Controls.GeoViewInputEventArgs e) => Element.RaiseGeoViewHolding(e);
        private void Control_GeoViewDoubleTapped(object sender, UI.Controls.GeoViewInputEventArgs e) => Element.RaiseGeoViewDoubleTapped(e);
        private void GeoViewRenderer_PropertyChanged(object sender, PropertyChangedEventArgs e) => Element.RaisePropertyChanged(e.PropertyName);

        private bool _isDisposed;

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                if (Control != null)
                {
                    Element.NativeGeoView = null;
                    Control.DrawStatusChanged -= Control_DrawStatusChanged;
                    Control.SpatialReferenceChanged -= Control_SpatialReferenceChanged;
                    Control.ViewpointChanged -= Control_ViewpointChanged;
                    Control.GeoViewTapped -= Control_GeoViewTapped;
                    Control.LayerViewStateChanged -= Control_LayerViewStateChanged;
                    Control.GeoViewTapped -= Control_GeoViewTapped;
                    Control.GeoViewDoubleTapped -= Control_GeoViewDoubleTapped;
                    Control.GeoViewHolding -= Control_GeoViewHolding;
                    Control.NavigationCompleted -= Control_NavigationCompleted;
                    (Control as INotifyPropertyChanged).PropertyChanged += GeoViewRenderer_PropertyChanged;
                }
            }
            _isDisposed = true;
            base.Dispose(disposing);
        }
    }
}
