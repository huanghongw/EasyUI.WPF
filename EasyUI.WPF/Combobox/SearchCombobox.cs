using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyUI.WPF.Combobox
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:EasyUI.WPF.Combobox"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:EasyUI.WPF.Combobox;assembly=EasyUI.WPF.Combobox"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:SearchCombobox/>
    ///
    /// </summary>
    [TemplatePart(Name = SearchCombobox.ElementContentTextBox, Type = typeof(TextBox))]
    public class SearchCombobox : ComboBox
    {
        private const string ElementContentTextBox = "PART_ContentTextBox";
        TextBox keyWords = null;
        static SearchCombobox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchCombobox), new FrameworkPropertyMetadata(typeof(SearchCombobox)));
        }
        public SearchCombobox()
        {

            //DefaultStyleKeyProperty.OverrideMetadata(typeof(EasyCombobox), new FrameworkPropertyMetadata(typeof(EasyCombobox)));

        }
        protected new IEnumerable ItemsSource
        {
            get
            {
                return base.ItemsSource;
            }
            private set
            {

                if (value == null)
                {
                    ClearValue(ItemsSourceProperty);
                }
                else
                {
                    SetValue(ItemsSourceProperty, value);
                }
            }
        }

        public IEnumerable<Object> OriginalSource
        {
            get { return (IEnumerable<Object>)GetValue(EasyItemSourceProperty); }
            set { SetValue(EasyItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EasyItemSourceProperty =
            DependencyProperty.Register("OriginalSource", typeof(IEnumerable<Object>), typeof(SearchCombobox), new PropertyMetadata(null, new PropertyChangedCallback(OnOriginalSourceChanged)));

        private static void OnOriginalSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SearchCombobox x)
            {
                x.ItemsSource = x.OriginalSource;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            keyWords = GetTemplateChild(ElementContentTextBox) as TextBox;
            if (keyWords != null)
            {
                var bindChinese = new Binding("KeyWords")
                {
                    Source = this,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    Mode = BindingMode.TwoWay
                };
                keyWords.SetBinding(TextBox.TextProperty, bindChinese);
            }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(SearchCombobox), new PropertyMetadata(new CornerRadius(0)));



        public int DropListHeight
        {
            get { return (int)GetValue(DropListHeightProperty); }
            set { SetValue(DropListHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DropListHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DropListHeightProperty =
            DependencyProperty.Register("DropListHeight", typeof(int), typeof(SearchCombobox), new PropertyMetadata(200));



        public string KeyWords
        {
            get { return (string)GetValue(KeyWordsProperty); }
            set { SetValue(KeyWordsProperty, value); }
        }
        public static readonly DependencyProperty KeyWordsProperty = DependencyProperty.Register("KeyWords", typeof(string), typeof(SearchCombobox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, OnTextPropertyChanged, CoerceText, isAnimationProhibited: true, UpdateSourceTrigger.LostFocus));

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SearchCombobox x)
            {
                if (x.OriginalSource != null)
                {
                    var tt = from p in x.OriginalSource where p.GetType().GetProperty(x.DisplayMemberPath).GetValue(p).ToString().Contains(x.KeyWords) select p;
                    x.ItemsSource = tt;
                }
            }
            //TextBox textBox = (TextBox)d;
            //if (!textBox._isInsideTextContentChange || (textBox._newTextValue != DependencyProperty.UnsetValue && !(textBox._newTextValue is DeferredTextReference)))
            //{
            //    textBox.OnTextPropertyChanged((string)e.OldValue, (string)e.NewValue);
            //}

        }

        private static object CoerceText(DependencyObject d, object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value;
        }


    }
}
