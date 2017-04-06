﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows.Media;



namespace RCC300A100Tester
{

    public class ViewModelMainWindow : BindableBase
    {



        public ViewModelMainWindow()
        {
            SelectIndex = -1;


        }
        //フラグ
        private bool _SetOperator;
        public bool SetOperator
        {
            get { return _SetOperator; }
            set
            {
                SetProperty(ref _SetOperator, value);
                if (value)
                {
                    if (Operator == "畔上")
                    {
                        State.VmTestStatus.EnableUnitTest = System.Windows.Visibility.Visible;
                    }
                }
                else
                {
                    Operator = "";
                    State.VmTestStatus.EnableUnitTest = System.Windows.Visibility.Hidden;
                    SelectIndex = -1;


                }
            }
        }



        private bool _SetOpecode;
        public bool SetOpecode
        {
            get { return _SetOpecode; }

            set
            {
                SetProperty(ref _SetOpecode, value);

                if (!value)
                {
                    Opecode = "";
                }

            }
        }




        //プロパティ

        private List<string> _ListOperator;
        public List<string> ListOperator
        {

            get { return _ListOperator; }
            set { SetProperty(ref _ListOperator, value); }

        }


        private string _Theme;
        public string Theme
        {
            get { return _Theme; }
            set { SetProperty(ref _Theme, value); }
        }


        private double _ThemeOpacity;
        public double ThemeOpacity
        {
            get { return _ThemeOpacity; }
            set { SetProperty(ref _ThemeOpacity, value); }
        }

        private int _SelectIndex;
        public int SelectIndex
        {

            get { return _SelectIndex; }
            set { SetProperty(ref _SelectIndex, value); }

        }

        private string _Operator;
        public string Operator
        {
            get { return _Operator; }
            set { SetProperty(ref _Operator, value); }
        }



        private string _Opecode;
        public string Opecode
        {
            get { return _Opecode; }
            set { SetProperty(ref _Opecode, value); }
        }



        private bool _EnableOtherButton;
        public bool EnableOtherButton
        {
            get { return _EnableOtherButton; }
            set { SetProperty(ref _EnableOtherButton, value); }
        }



        private Brush _Color日常点検;
        public Brush Color日常点検
        {
            get { return _Color日常点検; }
            set { SetProperty(ref _Color日常点検, value); }
        }



        private int _TabIndex;
        public int TabIndex
        {

            get { return _TabIndex; }
            set { SetProperty(ref _TabIndex, value); }

        }












    }
}
