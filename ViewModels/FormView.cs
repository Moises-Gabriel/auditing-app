using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Avalonia.Reactive;
using Avalonia.Controls;

namespace audit.ViewModels
{
    public class FormView:ViewModelBase
    {
        private List<string> dataList = new List<string>();

        public List<string> userData = new List<string>();
        public List<string> deptData = new List<string>();

        public FormView()
        {
            var command = ReactiveUI.ReactiveCommand.Create(OnClick);
        }

        public void OnClick()
        {
            //Add User Form Data to List
            dataList.Add(userData[0]);
            dataList.Add(userData[1]);
            //Add Department Form Data to List
            dataList.Add(deptData[0]);
            dataList.Add(deptData[1]);
            dataList.Add(deptData[2]);
            dataList.Add(deptData[3]);
        }
    }
}
