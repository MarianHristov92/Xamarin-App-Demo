using System;
using System.ComponentModel;
using DemoApp.Base.Views;
using DemoApp.iOS.Renderers;
using DemoAppBackendApi.Events;
using EventBus;
using EventBus.Interfaces;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomCollectionView), typeof(CustomCollectionViewRenderer))]
namespace DemoApp.iOS.Renderers
{
    public class CustomCollectionViewRenderer : CollectionViewRenderer
    {
        bool isScrollable = false;
        private ISubscription<BottomSheetPositionChangedEvent> BottomSheetPositionChangedSub { get; set; }
        UICollectionView collectionView;
        public CustomCollectionViewRenderer()
        {
            BottomSheetPositionChangedSub = MessageBus.Instance.Subscribe<BottomSheetPositionChangedEvent>(OnBottomSheetPositionChanged);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<GroupableItemsView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                NSArray CollectioViewArray = Control.ValueForKey(new NSString("_subviewCache")) as NSMutableArray;
                collectionView = CollectioViewArray.GetItem<UICollectionView>(0);
                collectionView.ScrollEnabled = isScrollable;
            }

        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs changedProperty)
        {
            base.OnElementPropertyChanged(sender, changedProperty);
            collectionView.ScrollEnabled = isScrollable;
        }

        public void OnBottomSheetPositionChanged(BottomSheetPositionChangedEvent e)
        {
            collectionView.ScrollEnabled = isScrollable = e.isCollectionViewScrollable;
        }

        protected override void Dispose(bool disposing)
        {
            base.ItemsView.SelectedItem = null;
            base.ItemsView.ItemsSource = null;
            base.Dispose(disposing);
        }
    }
}