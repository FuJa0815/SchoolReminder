using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using WPFHelper;

namespace SaveTheDayFX {
    internal class MainViewModel : BaseViewModel {
        #region const
        public const string FILEPATH = "save.xml";
        #endregion
        #region ctor
        public MainViewModel() {
            using (_stream = new FileStream(FILEPATH, FileMode.Open)) {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(DateTime));
                Date = (xsSubmit.Deserialize(_stream) as DateTime?) ?? DateTime.Now;
            }
        }
        #endregion
        #region var
        private BasicCommand _selectedItemChangedCommand;
        private FileStream _stream;
        #endregion
        #region Prop
        public DateTime Date { get; set; }
        #endregion
        #region Commands
        public BasicCommand SelectedItemChangedCommand => _selectedItemChangedCommand ?? (_selectedItemChangedCommand = new BasicCommand(() => {
            using (_stream = new FileStream(FILEPATH, FileMode.Create)) {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(DateTime));
                using (XmlWriter writer = XmlWriter.Create(_stream)) {
                    xsSubmit.Serialize(writer, Date);
                }
                _stream.Flush();
            }
        }));
        #endregion
    }
}
