using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using UiPath.CodedWorkflows;
using UiPath.Core;
using UiPath.Core.Activities.Storage;
using UiPath.Excel;
using UiPath.Excel.Activities;
using UiPath.Excel.Activities.API;
using UiPath.Excel.Activities.API.Models;
using UiPath.Orchestrator.Client.Models;
using UiPath.UIAutomationNext.API.Contracts;
using UiPath.UIAutomationNext.API.Models;
using UiPath.UIAutomationNext.Enums;
using WhatsappBulkMessageSender.ObjectRepository;

namespace WhatsappBulkMessageSender
{
    public class Copy_Media_Folder : CodedWorkflow
    {
        [Workflow]
        public void Execute(string in_str_mediaFolder)
        {
            StringCollection paths = new();
            paths.Add(in_str_mediaFolder);
            
            Thread thread = new(() => Clipboard.SetFileDropList(paths));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
}
