using System;
using System.Windows.Forms;
using PriorityQueue;

namespace TestProgram
{
    public partial class QueueManager : Form
    {
        IPriorityQueue<Person> queue;

        public QueueManager()
        {
            InitializeComponent();

            CB_Implementation.Items.Add("Sorted Array Priority Queue");
            CB_Implementation.Items.Add("Unsorted Array Priority Queue");
            CB_Implementation.Items.Add("Unsorted Linked Priority Queue");
            CB_Implementation.Items.Add("Sorted Linked Priority Queue");
            CB_Implementation.Items.Add("Heap Priority Queue");

            // Hide control panels until an interface is selected
            Panel_Add.Visible = false;
            Panel_Actions.Visible = false;
            Panel_Output.Visible = false;
        }

        private void CB_Implementation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel_Add.Visible = true;
            Panel_Actions.Visible = true;
            Panel_Output.Visible = true;

            if (CB_Implementation.SelectedIndex == 0)
            {
                InitSortedArrayQueue();
            }
            else if (CB_Implementation.SelectedIndex == 1)
            {
                InitUnsortedArrayQueue();
            }
        }

        private void InitSortedArrayQueue()
        {
            queue = new SortedArrayPriorityQueue<Person>(100);
            Lbl_Output.Text = "New sorted array priority queue created";
        }

        private void InitUnsortedArrayQueue()
        {
            queue = new UnsortedArrayPriorityQueue<Person>(100);
            Lbl_Output.Text = "New unsorted array priority queue created";
        }

        private void Btn_AddQueue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_Person.Text) == false)
            {
                Person person = new Person(Txt_Person.Text);
                int priority = (int)Num_Priority.Value;
                try
                {
                    queue.Enqueue(person, priority);
                    Lbl_Output.Text = "Added " + person.ToString();
                }
                catch (QueueOverflowException exception)
                {
                    Lbl_Output.Text = exception.Message;
                }

                return;
            }
            Lbl_Output.Text = "Please include name for new priority queue item";
        }

        private void Btn_Peek_Click(object sender, EventArgs e)
        {
            try
            {
                string name = queue.Peek().ToString();
                Lbl_Output.Text = "The person at the head of the queue is " + name;
            }
            catch (QueueUnderflowException exception)
            {
                Lbl_Output.Text = exception.Message;
            }
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                string name = queue.Peek().ToString();
                queue.Dequeue();
                Lbl_Output.Text = $"Removed {name} from queue";
            }
            catch (QueueUnderflowException exception)
            {
                Lbl_Output.Text = exception.Message;
            }
        }

        private void Btn_IsEmpty_Click(object sender, EventArgs e)
        {
            Lbl_Output.Text = queue.IsEmpty() ? "The queue is empty" : "The queue is NOT empty";
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                Lbl_Output.Text = queue.ToString();
            }
            catch (QueueUnderflowException exception)
            {
                Lbl_Output.Text = exception.Message;
            }
        }
    }
}
