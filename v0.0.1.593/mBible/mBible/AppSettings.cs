
using System;
using System.IO.IsolatedStorage;
using System.Diagnostics;

namespace mBible
{
    public class AppSettings
    {

        // Our isolated storage settings
        IsolatedStorageSettings settings;

        // The isolated storage key names of our settings
        const string FirstTimeSettingKeyName = "FirstTimeSetting";
        const string InitialSetupSettingKeyName = "InitialSetupSetting";
        const string BooksSetupSettingKeyName = "BooksSetupSetting";
        const string VersesSetupSettingKeyName = "VersesSetupSetting";
        const string SeenTutorialSettingKeyName = "SeenTutorialSetting";
        const string CurrentTestamentSettingKeyName = "CurrentTestamentSetting";
        const string CurrentEnglishSettingKeyName = "CurrentEnglishSetting";
        const string CurrentAbbrevSettingKeyName = "CurrentAbbrevSetting";
        const string CurrentSwahiliSettingKeyName = "CurrentSwahiliSetting";
        const string CurrentBookSettingKeyName = "CurrentBookSetting";
        const string CurrentChaptersSettingKeyName = "CurrentChaptersSetting";
        const string SelectedChapterSettingKeyName = "SelectedChapterSetting";
        const string SelectedVerseSettingKeyName = "SelectedVerseSetting";
        const string FontSizeSettingKeyName = "FontSizeSetting";
        const string FontTypeSettingKeyName = "FontTypeSetting";
        const string InstalledonSettingKeyName = "InstalledonSetting";
        const string LastParaidSettingKeyName = "LastParaidSetting";
        const string SkippedRatingSettingKeyName = "SkippedRatingSetting";
        const string RatedTSWSettingKeyName = "RatedTSWSetting";
        const string LastSearchSettingKeyName = "LastSearchSetting";
        const string Hint1SettingKeyName = "Hint1Setting";
        const string Hint2SettingKeyName = "Hint2Setting";
        const string Hint3SettingKeyName = "Hint3Setting";
        const string Hint4SettingKeyName = "Hint4Setting";
        const string Hint5SettingKeyName = "Hint5Setting";
        const string Hint6SettingKeyName = "Hint6Setting";
        const string Hint7SettingKeyName = "Hint7Setting";
        const string MessageFindSettingKeyName = "MessageFindSetting";
        const string MessageSearchSettingKeyName = "MessageSearchSetting";
        const string LastLoadedSettingKeyName = "LastLoadedSetting";

        // The default value of our settings
        const bool FirstTimeSettingDefault = false;
        const bool InitialSetupSettingDefault = false;
        const bool BooksSetupSettingDefault = false;
        const bool VersesSetupSettingDefault = false;
        const bool SeenTutorialSettingDefault = false;
        const int CurrentTestamentSettingDefault = 1;
        const string CurrentEnglishSettingDefault = "Genesis";
        const string CurrentAbbrevSettingDefault = "Gen.";
        const string CurrentSwahiliSettingDefault = "Mwanzo";
        const int CurrentBookSettingDefault = 1;
        const int CurrentChaptersSettingDefault = 50;
        const int SelectedChapterSettingDefault = 1;
        const int SelectedVerseSettingDefault = 1;
        const int FontSizeSettingDefault = 50;
        const string FontTypeSettingDefault = "Arial";
        const long InstalledonSettingDefault = 0;
        const int LastParaidSettingDefault = 1;
        const long SkippedRatingSettingDefault = 0;
        const bool RatedTSWSettingDefault = false;
        const string LastSearchSettingDefault = "";
        const bool Hint1SettingDefault = false;
        const bool Hint2SettingDefault = false;
        const bool Hint3SettingDefault = false;
        const bool Hint4SettingDefault = false;
        const bool Hint5SettingDefault = false;
        const bool Hint6SettingDefault = false;
        const bool Hint7SettingDefault = false;
        const bool MessageFindSettingDefault = false;
        const bool MessageSearchSettingDefault = false;
        const int LastLoadedSettingDefault = 1;

        /// <summary>
        /// Constructor that gets the application settings.
        /// </summary>
        public AppSettings()
        {
            try
            {
                // Get the settings for this application.
                settings = IsolatedStorageSettings.ApplicationSettings;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (settings.Contains(Key))
            {
                // If the value has changed
                if (settings[Key] != value)
                {
                    // Store the new value
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }

            return valueChanged;
        }


        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="valueType"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
        {
            valueType value;

            // If the key exists, retrieve the value.
            if (settings.Contains(Key))
            {
                value = (valueType)settings[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }

            return value;
        }


        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            settings.Save();
        }


        /// <summary>
        /// Property to get and set a RadioButton Setting Key.
        /// </summary>
        public bool FirstTimeSetting
        {
            get
            {
                return GetValueOrDefault<bool>(FirstTimeSettingKeyName, FirstTimeSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(FirstTimeSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool InitialSetupSetting
        {
            get
            {
                return GetValueOrDefault<bool>(InitialSetupSettingKeyName, InitialSetupSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(InitialSetupSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool BooksSetupSetting
        {
            get
            {
                return GetValueOrDefault<bool>(BooksSetupSettingKeyName, BooksSetupSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(BooksSetupSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool VersesSetupSetting
        {
            get
            {
                return GetValueOrDefault<bool>(VersesSetupSettingKeyName, VersesSetupSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(VersesSetupSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        public bool SeenTutorialSetting
        {
            get
            {
                return GetValueOrDefault<bool>(SeenTutorialSettingKeyName, SeenTutorialSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(SeenTutorialSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        public int CurrentTestamentSetting
        {
            get
            {
                return GetValueOrDefault<int>(CurrentTestamentSettingKeyName, CurrentTestamentSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CurrentTestamentSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public string CurrentEnglishSetting
        {
            get
            {
                return GetValueOrDefault<string>(CurrentEnglishSettingKeyName, CurrentEnglishSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CurrentEnglishSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public string CurrentAbbrevSetting
        {
            get
            {
                return GetValueOrDefault<string>(CurrentAbbrevSettingKeyName, CurrentAbbrevSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CurrentAbbrevSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public string CurrentSwahiliSetting
        {
            get
            {
                return GetValueOrDefault<string>(CurrentSwahiliSettingKeyName, CurrentSwahiliSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CurrentSwahiliSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public int CurrentBookSetting
        {
            get
            {
                return GetValueOrDefault<int>(CurrentBookSettingKeyName, CurrentBookSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CurrentBookSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public int CurrentChaptersSetting
        {
            get
            {
                return GetValueOrDefault<int>(CurrentChaptersSettingKeyName, CurrentChaptersSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CurrentChaptersSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public int SelectedChapterSetting
        {
            get
            {
                return GetValueOrDefault<int>(SelectedChapterSettingKeyName, SelectedChapterSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(SelectedChapterSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public int SelectedVerseSetting
        {
            get
            {
                return GetValueOrDefault<int>(SelectedVerseSettingKeyName, SelectedVerseSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(SelectedVerseSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        /// <summary>
        /// Property to get and set a FontSize Setting Key.
        /// </summary>
        public int FontSizeSetting
        {
            get
            {
                return GetValueOrDefault<int>(FontSizeSettingKeyName, FontSizeSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(FontSizeSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        /// <summary>
        /// Property to get and set a FontType Setting Key.
        /// </summary>
        public string FontTypeSetting
        {
            get
            {
                return GetValueOrDefault<string>(FontTypeSettingKeyName, FontTypeSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(FontTypeSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        /// <summary>
        /// Property to get and set a RadioButton Setting Key.
        /// </summary>
        public long InstalledonSetting
        {
            get
            {
                return GetValueOrDefault<long>(InstalledonSettingKeyName, InstalledonSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(InstalledonSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public int LastParaidSetting
        {
            get
            {
                return GetValueOrDefault<int>(LastParaidSettingKeyName, LastParaidSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(LastParaidSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public long SkippedRatingSetting
        {
            get
            {
                return GetValueOrDefault<long>(SkippedRatingSettingKeyName, SkippedRatingSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(SkippedRatingSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool RatedTSWSetting
        {
            get
            {
                return GetValueOrDefault<bool>(RatedTSWSettingKeyName, RatedTSWSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(RatedTSWSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public string LastSearchSetting
        {
            get
            {
                return GetValueOrDefault<string>(LastSearchSettingKeyName, LastSearchSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(LastSearchSettingKeyName, value))
                {
                    Save();
                }
            }
        }


        public bool Hint1Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint1SettingKeyName, Hint1SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint1SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint2Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint2SettingKeyName, Hint2SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint2SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint3Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint3SettingKeyName, Hint3SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint3SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint4Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint4SettingKeyName, Hint4SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint4SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint5Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint5SettingKeyName, Hint5SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint5SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint6Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint6SettingKeyName, Hint6SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint6SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool Hint7Setting
        {
            get
            {
                return GetValueOrDefault<bool>(Hint7SettingKeyName, Hint7SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(Hint7SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool MessageFindSetting
        {
            get
            {
                return GetValueOrDefault<bool>(MessageFindSettingKeyName, MessageFindSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(MessageFindSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool MessageSearchSetting
        {
            get
            {
                return GetValueOrDefault<bool>(MessageSearchSettingKeyName, MessageSearchSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(MessageSearchSettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public int LastLoadedSetting
        {
            get
            {
                return GetValueOrDefault<int>(LastLoadedSettingKeyName, LastLoadedSettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(LastLoadedSettingKeyName, value))
                {
                    Save();
                }
            }
        }
    }
}
