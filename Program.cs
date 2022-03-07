using Microsoft.Win32;

namespace Proxified_Connector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DRIVE VARIABLES
            string[] driveArray = new string[50];
            string driveNames = String.Empty;
            string selectedDrive = String.Empty;
            int driveIndex = 0;
            bool isDriveValid = false;

            // TAKES DRIVER INFORMATION
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            // WRITES DRIVERS
            foreach (DriveInfo d in allDrives)
            {
                // SETS THE ARRAY & SETS THE WHOLE STRING
                driveArray[driveIndex] = d.Name.Substring(0, 2);
                driveNames += d.Name.Substring(0, 2) + " ";

                // INCREASES INDEX OF ARRAY
                driveIndex++;
            }

            // CLEARS THE LAST SPACE
            driveNames = driveNames.Substring(0, driveNames.Length - 1);

            // SETS THE DRIVE
            do
            {
                Console.Write($"Select Drive ({driveNames}) --> ");
                selectedDrive = Console.ReadLine();

                // SETS THE STRING TO UPPER
                selectedDrive = selectedDrive.ToUpper();

                // ADDS THE COLON IF IT DOESN'T CONTAINS
                if (!selectedDrive.Contains(":"))
                {
                    selectedDrive += ":";
                }

                // LINE SPACE
                Space();

                for (int i = 0; i < driveArray.Length - 1; i++)
                {
                    if (selectedDrive == driveArray[i])
                    {
                        isDriveValid = true;
                        break;
                    }
                }
            } while (!isDriveValid);

            if (File.Exists(selectedDrive + @"\Proxified\Proxylist.txt"))
            {
                // INFORMATION LOG
                Console.WriteLine("|######################################|");
                Console.WriteLine("|         Proxified List Found         |");
                Console.WriteLine("|######################################|");
            }
            else
            {
                // INFORMATION LOG
                Console.WriteLine("|######################################|");
                Console.WriteLine("|       Proxified List Not Found       |");
                Console.WriteLine("|######################################|");
            }

            Console.ReadLine();
        }

        private static void Space()
        {
            Console.WriteLine("");
        }
    }
}