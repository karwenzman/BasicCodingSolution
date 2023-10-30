using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicCodingWpf.ViewModels;

public abstract class ViewModelBase : ObservableObject, INotifyPropertyChanged
{
    ///// <summary>
    ///// Event 'PropertyChanged'. 
    ///// This is supported by interface 'INotifyPropertyChanged'.
    ///// </summary>
    //public event PropertyChangedEventHandler? PropertyChanged;

    ///// <summary>
    ///// Method throwing the event. This method can be inherited and derived classes can use the event 'PropertyChanged'.
    ///// This is supported by interface 'INotifyPropertyChanged'.
    ///// <para></para>
    ///// If 'PropertyName' is not provided, the 'CallMemberName' attribute gets this information during runtime.
    ///// </summary>
    ///// <param name="propertyName">Optional: the property where the method is called from.</param>
    //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}

    ///// <summary>
    ///// Method throwing the event. This method can be inherited and derived classes can use the event 'PropertyChanged'.
    ///// This is supported by interface 'INotifyPropertyChanged'.
    ///// The additional value of this method is, that it does compare the current and the new value.
    ///// <para></para>
    ///// It is an alternative method to throw the event 'Property Changed'.
    ///// If 'PropertyName' is not provided, the 'CallMemberName' attribute gets this information during runtime.
    ///// </summary>
    ///// <remarks>
    ///// This method can be used instead of 'OnPropertyChanged()'.
    ///// </remarks>
    ///// <typeparam name="T"></typeparam>
    ///// <param name="storage">The private field storing the current value.</param>
    ///// <param name="value">The new value, if it differs from the current value.</param>
    ///// <param name="propertyName">Optional: the property where the method is called from.</param>
    //protected virtual void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
    //{
    //    if (Object.Equals(storage, value)) return;
    //    storage = value;
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}

}
