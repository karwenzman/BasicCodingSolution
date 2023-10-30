using BasicCodingWpf.ViewModels;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace BasicCodingWpf.Views;

public partial class PaperDeliveryStartupView : Window
{
    public PaperDeliveryStartupView(ILogger<PaperDeliveryStartupView> logger, IPaperDeliveryStartupViewModel paperDeliveryStartupViewModel)
    {
        logger.LogInformation("* Loading: {class}", nameof(PaperDeliveryStartupView));

        DataContext = paperDeliveryStartupViewModel;
        CommandBindings.Add(paperDeliveryStartupViewModel.CommandBinding_Stop);
        Closing += paperDeliveryStartupViewModel.PaperDeliveryStartupView_Closing;
        InitializeComponent();
    }
}
