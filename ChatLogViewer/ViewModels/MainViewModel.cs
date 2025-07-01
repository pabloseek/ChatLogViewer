using ChatLogViewer.Models;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace ChatLogViewer.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<ChatMessage> ChatMessages { get; } = new();

        public void LoadFromFile()
        {
            var ofd = new OpenFileDialog { Filter = "Text files (*.txt)|*.txt" };
            if (ofd.ShowDialog() != true) return;

            ChatMessages.Clear();
            var lines = File.ReadAllLines(ofd.FileName);
            DateTime currentTimestamp = DateTime.MinValue;

            foreach (var line in lines)
            {
                if (Regex.IsMatch(line, @"^\d{2}:\d{2} \d{2}\.\d{2}\.\d{4}$"))
                {
                    currentTimestamp = DateTime.ParseExact(line, "HH:mm dd.MM.yyyy", CultureInfo.InvariantCulture);
                }
                else if (line.Contains(":"))
                {
                    var index = line.IndexOf(":");
                    var user = line[..index].Trim();
                    var msg = line[(index + 1)..].Trim();

                    ChatMessages.Add(new ChatMessage
                    {
                        Timestamp = currentTimestamp,
                        Username = user,
                        Message = msg
                    });
                }
            }
        }
    }
}
