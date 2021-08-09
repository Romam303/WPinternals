﻿// Copyright (c) 2018, Rene Lergner - wpinternals.net - @Heathcliff74xda
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WPinternals
{
    /// <summary>
    /// Interaction logic for FlashRomView.xaml
    /// </summary>
    public partial class FlashRomView : UserControl
    {
        public FlashRomView()
        {
            InitializeComponent();
        }

        private void HandleHyperlinkClick(object sender, RoutedEventArgs args)
        {
            if (args.Source is Hyperlink link)
            {
                if (link.NavigateUri.ToString() == "UnlockBoot")
                {
                    (this.DataContext as LumiaFlashRomSourceSelectionViewModel)?.SwitchToUnlockBoot();
                }
                else if (link.NavigateUri.ToString() == "UnlockRoot")
                {
                    (this.DataContext as LumiaFlashRomSourceSelectionViewModel)?.SwitchToUnlockRoot();
                }
                else if (link.NavigateUri.ToString() == "Dump")
                {
                    (this.DataContext as LumiaFlashRomSourceSelectionViewModel)?.SwitchToDumpFFU();
                }
                else if (link.NavigateUri.ToString() == "Backup")
                {
                    (this.DataContext as LumiaFlashRomSourceSelectionViewModel)?.SwitchToBackup();
                }
            }
        }

        private void Document_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as FlowDocument)?.AddHandler(Hyperlink.ClickEvent, new RoutedEventHandler(HandleHyperlinkClick));
        }

        private void FilePicker_PathChanged(object sender, PathChangedEventArgs e)
        {
            ((LumiaFlashRomSourceSelectionViewModel)DataContext).EvaluateViewState();
        }
    }
}
