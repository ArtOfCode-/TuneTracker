using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TuneTracker.Exceptions;

namespace TuneTracker.Modules
{
    public class AudioTrack
    {
        /// <summary>
        /// Gets or sets the location of the audio file.
        /// </summary>
        public string AudioFileLocation { get; set; }

        /// <summary>
        /// Gets or sets the type of audio file this instance represents.
        /// </summary>
        public string AudioFileType { get; set; }

        /// <summary>
        /// Initialises a new instance of the AudioTrack class.
        /// </summary>
        public AudioTrack(string audioFilePath)
        {
            string filetype = Path.GetExtension(audioFilePath).ToLower();
            AudioFileLocation = audioFilePath;
            AudioFileType = filetype;
            if (AudioFileType != "mp3" && AudioFileType != "wav")
            {
                throw new FileTypeException(string.Format("Type {0} is not a supported audio file type.", AudioFileType));
            }
        }
    }
}
