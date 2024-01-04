/* README
 # Tic Tac Toe Game 

  - Programming language   : `C#` 
  - Framework              : `.NET 8` 
  - IDE                    : `Visual Studio 2022`
  - Developer Platform     : `Windows 11`
  - Supported Platform(s)  : `Windows`

## Functions
  - All fields generated at runtime, allowing future upgrade to size changes
    - This means. The size of the gui can be changed by altering  `int boxSizeWidth = 120;` for width, `int boxSizeHeight = 120;` for height. These variables are in the `initializeMultiplayer()` method of `Form1`
  - Checks for winners only if the `placedCounter >= 5 ` which is the minimum moves it takes for a win
  - automatically resets the fields when a player wins or all the fields are filled without a winner. (no reset button) 
  
 */

namespace TicTacToedDotNet
{
    public partial class Form1 : Form
    {
        private bool isPlayerOneTurn = true; // To track whose turn it is
        int moveCounter = 0;
        private Button[,] buttons = new Button[3, 3];


        public Form1()
        {
            InitializeComponent();
            initializeMultiplayer();
            initializeGameMap();
        }

        private void initializeMultiplayer()
        {
            int boxSizeWidth = 120;
            int boxSizeHeight = 120;
            int boxGapBetween = 1;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button button = new Button();
                    button.Size = new Size(boxSizeWidth, boxSizeHeight);
                    button.Location = new Point(boxGapBetween + col * (boxSizeWidth + 1), boxGapBetween + row * (boxSizeHeight + boxGapBetween));
                    button.Click += Button_Click; // this is crucial it subscribes to the event listener
                                                  // that means everytime any of these buttons gets clicked the same event listener will respond
                    button.Font = GetAdjustedFont(button);
                    buttons[row, col] = button;
                    panel1.Controls.Add(button);
                }
            }
            panel1.Dock = DockStyle.Fill;
            // calculate new size for the panel and form
            // width calculation
            // we have 3 boxes side by side each 120px 
            //  Height calculation
            // we have 3 boxes top to bottom with each 120px of height
            // and we have gaps 
            // between 1st and 2nd
            // between 2nd and 3rd
            // between left corner of panel and 1st 
            // between right corner of panel and 3rd
            // SO 4 IN TOTAL
            int panelWidth = (boxSizeWidth * 3) + (boxGapBetween * 4);
            int panelHeight = (boxSizeHeight * 3) + (boxGapBetween * 4);
            // now set the size of the panel and form according to the boxes
            panel1.Size = new Size(panelWidth + 2, panelHeight); // panelwidth+2 to make it look a bit better by not making right box colums stick to the panels border
            // and the code for form to automatically adjust its size to the contents 
            this.ClientSize = new Size(panelWidth, panelWidth); // this needs panel1.dock = dockstyle.fill in order to work as intended

            // Perform a layout update to ensure the form is resized immediately
            this.PerformLayout();


        }
        private void initializeGameMap()
        {

        }
        private void checkWinner()
        {

            if (
                // chekc first row
                buttons[0, 0].Text.Equals("X") &&
                buttons[0, 1].Text.Equals("X") &&
                buttons[0, 2].Text.Equals("X") ||
                // check second row
                buttons[1, 0].Text.Equals("X") &&
                buttons[1, 1].Text.Equals("X") &&
                buttons[1, 2].Text.Equals("X") ||
                // check third row
                buttons[2, 0].Text.Equals("X") &&
                buttons[2, 1].Text.Equals("X") &&
                buttons[2, 2].Text.Equals("X") ||

                // check first colum
                buttons[0, 0].Text.Equals("X") &&
                buttons[1, 0].Text.Equals("X") &&
                buttons[2, 0].Text.Equals("X") ||
                // check third row
                buttons[0, 1].Text.Equals("X") &&
                buttons[1, 1].Text.Equals("X") &&
                buttons[2, 1].Text.Equals("X") ||
                // check third row
                buttons[0, 2].Text.Equals("X") &&
                buttons[1, 2].Text.Equals("X") &&
                buttons[2, 2].Text.Equals("X") ||

                // check left to right cross
                buttons[0, 0].Text.Equals("X") &&
                buttons[1, 1].Text.Equals("X") &&
                buttons[2, 2].Text.Equals("X") ||

                // check right to left cross
                buttons[0, 2].Text.Equals("X") &&
                buttons[1, 1].Text.Equals("X") &&
                buttons[2, 0].Text.Equals("X")
                )
            {
                MessageBox.Show("Player 1 (X) Wins!!.", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // it wont continue to next line until the MessageBox is closed. so you can see the board

                ResetGame();
            }

            else if (
               // chekc first row
               buttons[0, 0].Text.Equals("O") &&
               buttons[0, 1].Text.Equals("O") &&
               buttons[0, 2].Text.Equals("O") ||
               // check second row
               buttons[1, 0].Text.Equals("O") &&
               buttons[1, 1].Text.Equals("O") &&
               buttons[1, 2].Text.Equals("O") ||
               // check third row
               buttons[2, 0].Text.Equals("O") &&
               buttons[2, 1].Text.Equals("O") &&
               buttons[2, 2].Text.Equals("O") ||

               // check first colum
               buttons[0, 0].Text.Equals("O") &&
               buttons[1, 0].Text.Equals("O") &&
               buttons[2, 0].Text.Equals("O") ||
               // check third row
               buttons[0, 1].Text.Equals("O") &&
               buttons[1, 1].Text.Equals("O") &&
               buttons[2, 1].Text.Equals("O") ||
               // check third row
               buttons[0, 2].Text.Equals("O") &&
               buttons[1, 2].Text.Equals("O") &&
               buttons[2, 2].Text.Equals("O") ||

               // check left to right cross
               buttons[0, 0].Text.Equals("O") &&
               buttons[1, 1].Text.Equals("O") &&
               buttons[2, 2].Text.Equals("O") ||

               // check right to left cross
               buttons[0, 2].Text.Equals("O") &&
               buttons[1, 1].Text.Equals("O") &&
               buttons[2, 0].Text.Equals("O")
               )
            {
                MessageBox.Show("Player 2 (O) Wins!!.", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // it wont continue to next line until the MessageBox is closed. so you can see the board
                ResetGame();

            }

        }

        private void ResetGame()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    buttons[row, col].Text = "";
                }
            }
            isPlayerOneTurn = true;
            moveCounter = 0;
        }

        private void Button_Click(object clickedButton, EventArgs e)
        {
            Button button = clickedButton as Button; // cast this type as button this is `safe casting`
                                                     // even though we know its a button this way allow us to use button dot actions

            // another way to do this cast is (button) clickedButton
                // but its not safe since it will throw an error if the clickedButton is not actually a button but another object

            //safe casting allow the button variable to be null if the clickedbutton is not actually a button...

            if (button != null && button.Text == "") // Check if the button is not already clicked
            {
                if (isPlayerOneTurn)
                {
                   button.Text = "X";
                   isPlayerOneTurn = false;
                }
                else
                {
                    button.Text = "O";
                    isPlayerOneTurn = true;
                }
                moveCounter++;
                if (moveCounter >= 5) checkWinner();
                if (moveCounter == 9) ResetGame();
            }

        }

     


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        // GPT MADE ALGORITHMS 
        // ANY ALGORITHM UNDER THIS COMMENT IS MADE BY CHATGPT-4
        private Font GetAdjustedFont(Button button)
        {
            // Start with a font size that is large but likely to fit
            float fontSize = button.ClientSize.Height * 0.5f; // Half the height of the button

            // Create a test font with the starting size
            Font testFont = new Font(button.Font.FontFamily, fontSize, FontStyle.Bold);

            // Measure how much space the "X" or "O" takes up
            SizeF stringSize = button.CreateGraphics().MeasureString("X", testFont);

            // Reduce the font size until the string fits within the button
            while (stringSize.Width > button.ClientSize.Width || stringSize.Height > button.ClientSize.Height)
            {
                fontSize--;
                testFont.Dispose(); // Dispose the old font before creating a new one
                testFont = new Font(button.Font.FontFamily, fontSize, FontStyle.Bold);
                stringSize = button.CreateGraphics().MeasureString("X", testFont);
            }

            return testFont;
        }
    }
}
