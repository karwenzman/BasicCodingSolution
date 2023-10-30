using PaperDeliveryLibrary.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace BasicCodingWpf.ViewModels
{
    public interface IPaperDeliveryStartupViewModel
    {
        CommandBinding CommandBinding_Stop { get; set; }

        PaperDeliverySetting PaperDeliverySetting { get; set; }
        string DeveloperName { get; set; }

        /// <summary>
        /// This is the event handler for the closing event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PaperDeliveryStartupView_Closing(object? sender, CancelEventArgs e);
    }
}