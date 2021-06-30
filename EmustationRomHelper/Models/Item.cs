namespace EmustationRomHelper.Models
{
    /// <summary>
    /// Class for storing file information when renaming files 
    /// for xbox file system
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The current name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The file name length
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// The new name
        /// </summary>
        public string NewName { get; set; }

        /// <summary>
        /// The file extension
        /// </summary>
        public string Extension { get; set; }
    }
}
