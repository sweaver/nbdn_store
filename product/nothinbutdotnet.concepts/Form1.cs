using System.Windows.Forms;

namespace nothinbutdotnet.concepts
{
    public partial class Form1 : Form
    {
        Service service;

        public Form1()
        {
            InitializeComponent();
            hookup_event_handlers();
        }
        public Form1(Service service):this()
        {
            this.service = service;
        }

        void hookup_event_handlers()
        {
            this.button1.Click += (o, e) => display_file_details();
        }

        void display_file_details()
        {
            var contents_of = service.display_contents_of(@"C:/tempfiles/info.txt");
            this.richTextBox1.Text = contents_of;
        }
    }
}