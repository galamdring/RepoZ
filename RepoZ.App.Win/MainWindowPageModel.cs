﻿using RepoZ.Api.Common.Common;
using RepoZ.Api.Common.Git.AutoFetch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoZ.App.Win
{
	public class MainWindowPageModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private AutoFetchMode _autoFetchMode;
		private AppSettings _appSettings;

		public MainWindowPageModel(IAppSettingsProvider appSettingsProvider)
		{
			AppSettingsProvider = appSettingsProvider ?? throw new ArgumentNullException(nameof(appSettingsProvider));
			_appSettings = appSettingsProvider.Load();
		}

		public AutoFetchMode AutoFetchMode
		{
			get => _appSettings.AutoFetchMode;
			set
			{
				_appSettings.AutoFetchMode = value;

				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AutoFetchMode)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AutoFetchOff)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AutoFetchDiscretely)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AutoFetchAdequate)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AutoFetchAggresive)));

				AppSettingsProvider.Save(_appSettings);
			}
		}

		public bool AutoFetchOff
		{
			get => AutoFetchMode == AutoFetchMode.Off;
			set => AutoFetchMode = AutoFetchMode.Off;
		}

		public bool AutoFetchDiscretely
		{
			get => AutoFetchMode == AutoFetchMode.Discretely;
			set => AutoFetchMode = AutoFetchMode.Discretely;
		}

		public bool AutoFetchAdequate
		{
			get => AutoFetchMode == AutoFetchMode.Adequate;
			set => AutoFetchMode = AutoFetchMode.Adequate;
		}

		public bool AutoFetchAggresive
		{
			get => AutoFetchMode == AutoFetchMode.Aggresive;
			set => AutoFetchMode = AutoFetchMode.Aggresive;
		}

		public IAppSettingsProvider AppSettingsProvider { get; }
	}
}
