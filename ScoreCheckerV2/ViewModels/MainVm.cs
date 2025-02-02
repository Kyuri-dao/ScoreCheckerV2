using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ScoreCheckerV2.ViewModels
{
    public partial class MainVm : ObservableValidator
    {
        [ObservableProperty]
        private ObservableCollection<SubjectTable> subjectTables;

        [ObservableProperty]
        private ObservableCollection<HistoryTable> historyList;

        public MainVm()
        {


            SubjectTables = new ObservableCollection<SubjectTable>()
            {
                new(){Key=1, ColorCode=Brush.BlueViolet, SubjectName="科目"},
                new(){Key=2, ColorCode=Brush.SpringGreen, SubjectName="科目"},
                new(){Key=3, ColorCode=Brush.Gold, SubjectName="科目"},
                new(){Key=4, ColorCode=Brush.Orange, SubjectName="科目"},
                new(){Key=5, ColorCode=Brush.Chartreuse, SubjectName="科目"},
                new(){Key=6, ColorCode=Brush.Crimson, SubjectName="科目"}
            };

            

            
           
        }
    }

    public partial class SubjectTable : ObservableObject
    {
        [ObservableProperty]
        private int? key;

        [ObservableProperty]
        private Brush? colorCode;

        
        //計算エリア
        [ObservableProperty]
        private int? firstQuarter;

        [ObservableProperty]
        private int? secondQuarter;

        [ObservableProperty]
        private int? thirdQuarter;

        [ObservableProperty]
        private int? fourthQuarter;

        [ObservableProperty]
        private int? returnedAnswer;

        [ObservableProperty]
        private string? returnedAnswerStr;

        //履歴用
        [ObservableProperty]
        private string? subjectName;

        public void Calculation()
        {
            // nullなら0を代入
            FirstQuarter ??= 0;
            SecondQuarter ??= 0;
            ThirdQuarter ??= 0;
            FourthQuarter ??= 0;

            ReturnedAnswer = 240 - FirstQuarter - SecondQuarter - ThirdQuarter - FourthQuarter;

            ReturnedAnswerStr = $"あと" + ReturnedAnswer.ToString() + "点";

            SubjectName ??= "不明な科目";

            Preferences.Default.Set("subject_info", SubjectName);
            Preferences.Default.Set("subject_score", ReturnedAnswerStr);
        }

        [RelayCommand]
        private void OnClickedCal()
        {
            Calculation();
        }

        

        
    }

    public partial class HistoryTable : ObservableObject
    {
        [ObservableProperty]
        private string? historySubjectName;

        [ObservableProperty]
        private string? viewSubjectName;

        [ObservableProperty]
        private string? historyReturnedAnswerStr;

        [ObservableProperty]
        private string? viewReturnedAnswerStr;

        public void GetHistory()
        {
            Preferences.Default.Get("subject_info", HistorySubjectName);
            Preferences.Default.Get("subject_score", HistoryReturnedAnswerStr);
        }
    }

        

    public class ColorSet
    {
        public void Color()
        {
            Random rnd = new Random();
            int rndVal = rnd.Next(1, 11);

            if(rndVal == 1)
            {

            }
        }
            
    }


        //[RelayCommand]
        //private async Task AddSubjectsTable()
        //{
        //    await Task.Delay(2500);
            //SubjectTables.Add();
        //}
}
