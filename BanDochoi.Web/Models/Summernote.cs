namespace BanDochoi.Web.Models
{
    public class Summernote
    {
        public string IDEditor { get; set; }
        public bool LoadLib { get; set; }
        public Summernote(string IDEditor, bool loadLib = true)
        {
            this.IDEditor = IDEditor;
            this.LoadLib = loadLib;
        }
        public int height { get; set; } = 120;
        public string toolbar { get; set; } = @"[
                ['style', ['style']],
                ['font', ['bold', 'underline', 'clear']],
                ['fontname', ['fontname']],
                ['fontsize', ['fontsize']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
                ['table', ['table']],
                ['insert', ['link', 'picture', 'video', 'elfinder']],
                ['height', ['height']],
                ['view', ['fullscreen', 'codeview', 'help']]
            ]";
    }
}
