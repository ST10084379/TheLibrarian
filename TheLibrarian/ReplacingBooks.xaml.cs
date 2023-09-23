using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TheLibrarian
{
    public partial class ReplacingBooks : Window, INotifyPropertyChanged
    {
        List<string> Books = new List<string>();
        List<string> Sortedbooks = new List<string>();
        List<string> UserScores = new List<string>();

        // Object of the dispatch timer 
        DispatcherTimer timer = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();

        private int count = 10;
        private int countDownTime = 30;
        private int timeScore;
        private int remainingSeconds;
        private string userName;
        private int score;
        private string userScore;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
            }
        }

        public ReplacingBooks()
        {
            DataContext = this;
            InitializeComponent();
            Instructions.Visibility = Visibility.Visible;
        }

        public void UpdateBooksListBox()
        {
            BookShelf.Items.Clear();
            foreach (var book in Books)
            {
                BookShelf.Items.Add(book);
            }   
        }

        public void AddItems()
        {
            Random rand = new Random();
            StringBuilder randomString = new StringBuilder(3);

            // Adding to the list
            for (int i = 0; i < 10; i++)
            {
                // Generate a random 3-character string
                string randomChars = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 3)
                                                         .Select(s => s[rand.Next(s.Length)]).ToArray());

                Books.Add(rand.Next(100, 999).ToString() + "." + rand.Next(10, 99).ToString() + " " + randomChars);
                Sortedbooks.Add(Books[i]);
            }
        }

        // Method that adds the username and the users score to the userScores list
        public void AddUserScores()
        {
            // Add to the list
            userScore = userName + " : " + score.ToString();
            UserScores.Add(userScore);
        }

        // Method to add the userScores list to the listbox
        public void UpdateUserScores()
        {
            UserScoresListBox.Items.Clear();
            foreach (var user in UserScores)
            {
                UserScoresListBox.Items.Add(user);
            }
        }

        public void SortedList()
        {
            if (Books != null)
            {
                bool swapped;
                do
                {
                    swapped = false;
                    for (int i = 0; i < Books.Count - 1; i++)
                    {
                        // Compare adjacent strings
                        if (string.Compare(Sortedbooks[i], Sortedbooks[i + 1]) > 0)
                        {
                            // Swap the strings
                            string temp = Sortedbooks[i];
                            Sortedbooks[i] = Sortedbooks[i + 1];
                            Sortedbooks[i + 1] = temp;
                            swapped = true;
                        }
                    }
                } while (swapped);

                string allItems = string.Join(Environment.NewLine, Sortedbooks);
                MessageBox.Show(allItems, "These are the Books in the Correct Order:");
            }
            else
            {
                MessageBox.Show("You need to start the game before comparing answers!");
            }
        }

        public void CompareList()
        {
            int tempSCore = Count;
            timeScore = remainingSeconds;
            score = tempSCore + timeScore;
            bool pass = false;

            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i] == Sortedbooks[i])
                {
                    pass = true;
                }
                else
                {
                    pass = false;
                }
            }

            if (pass)
            {

                if (score == 0)
                {
                    score++;
                }

                MessageBox.Show("Congradulations! You have sorted the list correctly");
                MessageBox.Show("Your score is: " + score);
                AddUserScores();
                UpdateUserScores();
                ResetTimer();
            }
            else
            {
                MessageBox.Show("Incorrect! Unfortunately you did not sort the list correctly");
                ResetTimer();
            }
        }

        private void ListBoxItem_Drop(object sender, DragEventArgs e) // Event handler
        {
            ListBoxItem targetItem = sender as ListBoxItem;
            if (targetItem != null)
            {
                int targetIndex = BookShelf.Items.IndexOf(targetItem.Content.ToString()); // Get the start index
                int draggedIndex = BookShelf.Items.IndexOf((string)e.Data.GetData(typeof(string))); // Get the end index

                if (targetIndex >= 0 && draggedIndex >= 0) // -> Check the position are valid 
                {
                    // Swapping the entries as the user moves them in the list
                    string temp = Books[draggedIndex];
                    Books.RemoveAt(draggedIndex);
                    Books.Insert(targetIndex, temp);

                    UpdateBooksListBox();
                    Count--;

                    if (Count == 0)
                    {
                        MessageBox.Show("No More Moves Left!");
                        BookShelf.IsEnabled = false;
                        UpdateBooksListBox();
                    }
                }
            }
        }

        private void ListBoxItem_PreviewMouseMove(object sender, MouseEventArgs e) // Event handler -> Mouse move over
        {
            if (e.LeftButton == MouseButtonState.Pressed) // -> Click initiate a drag drop
            {
                ListBoxItem draggedItem = sender as ListBoxItem; // -> DraggedItem -> Sets the user to move it
                if (draggedItem != null)
                {
                    // Allow the drag drop to happen
                    DragDrop.DoDragDrop(draggedItem, draggedItem.Content,
                        DragDropEffects.Move);
                }
            }
        }

        public void CountdownTimer()
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            stopwatch.Start();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            int elapsedSeconds = (int)(elapsedMilliseconds / 1000);

            remainingSeconds = countDownTime - elapsedSeconds;

            if (remainingSeconds >= 0)
            {
                countDown.Content = remainingSeconds.ToString("D2");
            }
            else if (remainingSeconds < 0)
            {
                BookShelf.IsEnabled = false;
                ResetTimer();
            }
        }

        private void ResetTimer()
        {
            stopwatch = new Stopwatch(); // Create a new Stopwatch instance
            countDown.Content = countDownTime.ToString("D2");
            countDownTime = 30;
            timer.Stop();
            stopwatch.Stop();
        }

        private void DisableAndClearListBox()
        {
            btnScoreBoard.IsEnabled = true;
            btnStart.IsEnabled = true;
            BookShelf.Background = new SolidColorBrush(Colors.Transparent);
            BookShelf.Items.Clear();
            BookShelf.IsEnabled = true;
            Books.Clear();
            Sortedbooks.Clear();
            Count = 10;
            tbUsername.Clear();
        }

        private void StartAndClearListBox()
        {
            btnScoreBoard.IsEnabled = false;
            btnStart.IsEnabled = false;
            Books.Clear();
            Sortedbooks.Clear();
            BookShelf.Background = new SolidColorBrush(Colors.BurlyWood);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            // Reset the timer
            ResetTimer();
            DisableAndClearListBox();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            UsernamePopup.IsOpen = true;
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            // Stop the timer
            timer.Stop();

            if (Books.Count == 0)
            {
                MessageBox.Show("You need to start the game before comparing answers!");
            }
            else
            {
                if (Count == 10)
                {
                    MessageBox.Show("Please sort the numbers before trying to check if the order is correct");
                }
                else
                {
                    SortedList();
                    CompareList();
                    DisableAndClearListBox();
                }
            }
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnScoreBoard_Click(object sender, RoutedEventArgs e)
        {
            UserScoreBoard.Visibility = Visibility.Visible;
            stkPlayButtons.IsEnabled = false;
            stkMenuButtons.IsEnabled = false;
        }

        private void btnCloseScoreboard_Click(object sender, RoutedEventArgs e)
        {
            UserScoreBoard.Visibility = Visibility.Hidden;
            stkPlayButtons.IsEnabled = true;
            stkMenuButtons.IsEnabled = true;
        }

        // Okay button action for the username popup
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

            if (tbUsername.Text.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("Please enter your username");
            }
            else
            {
                userName = tbUsername.Text;
                // Reset the timer
                ResetTimer();
                StartAndClearListBox();
                CountdownTimer();
                AddItems();
                UpdateBooksListBox();
                
                // Do something with the user's input
                UsernamePopup.IsOpen = false; // Close the popup
            }
           
        }

        // Cancel button action for the username popup
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            UsernamePopup.IsOpen = false; // Close the popup
        }

        private void CloseInstructions_Click(object sender, RoutedEventArgs e)
        {
            Instructions.Visibility = Visibility.Collapsed;
            stkPlayButtons.IsEnabled = true;
            stkMenuButtons.IsEnabled = true;    
        }
    }
}
