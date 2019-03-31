using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFCoinMidterm.Models;

namespace WPFCoinMidterm.ViewModels
{
    public class ViewModelDog : ViewModelBase
    {
        Dog dog;

        public ViewModelDog(Dog dog)
        {
            this.dog = dog;
        }

        // This is a wrapper that will take the MODEL Dog's properties and VIEW MODEL DOG is the remote the user uses to alter data
        public string Name
        {
            get { return this.dog.Name; }
            set {
                RaisePropertyChanged();
                this.dog.Name = value; }
        }

        public int Age
        {
            get { return this.dog.Age; }
            set {
                RaisePropertyChanged();
                this.dog.Age = value; }
        }

    }
}
