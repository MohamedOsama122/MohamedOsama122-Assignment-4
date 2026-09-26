using System;
using System.Text;
using AcademyScheduleAnalyzer.Benchmarks;
using BenchmarkDotNet.Running;

namespace AcademyScheduleAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // If passed --benchmark flag, run BenchmarkDotNet runner
            if (args.Length > 0 && args[0].Equals("--benchmark", StringComparison.OrdinalIgnoreCase))
            {
                BenchmarkRunner.Run<StringBenchmark>();
                return;
            }

            // Part 1: Starter Data
            string[] sessionNames =
            {
                "C# Basics",
                "Arrays",
                "Functions",
                "Date and Time",
                "Exception Handling"
            };

            DateTime[] sessionDates =
            {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 20, 18, 0, 0),
                new DateTime(2026, 9, 24, 18, 0, 0)
            };

            int[] sessionDurations =
            {
                180,
                240,
                180,
                240,
                180
            };

            // Execute language feature demonstrations (ref, out, reference types, params)
            DemonstrateLanguageFeatures(sessionNames, sessionDurations);

            // Part 31: Console Menu Loop (16 Options + 0 Exit)
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== Academy Schedule Analyzer ===");
                Console.WriteLine("1. Display all sessions");
                Console.WriteLine("2. Search for a session");
                Console.WriteLine("3. Sort session names");
                Console.WriteLine("4. Reverse session names");
                Console.WriteLine("5. Find session index");
                Console.WriteLine("6. Check if session exists");
                Console.WriteLine("7. Show duration statistics");
                Console.WriteLine("8. Show session date details");
                Console.WriteLine("9. Show past and upcoming sessions");
                Console.WriteLine("10. Find next session");
                Console.WriteLine("11. Compare two session dates");
                Console.WriteLine("12. Read and validate a custom date");
                Console.WriteLine("13. Select session by index");
                Console.WriteLine("14. Validate session duration");
                Console.WriteLine("15. Generate report using string");
                Console.WriteLine("16. Generate report using StringBuilder");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                int option = ReadMenuOption();

                switch (option)
                {
                    case 1:
                        DisplaySessions(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 2:
                        SearchSession(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 3:
                        SortSessionNames(sessionNames);
                        break;
                    case 4:
                        ReverseSessionNames(sessionNames);
                        break;
                    case 5:
                        FindSessionIndex(sessionNames);
                        break;
                    case 6:
                        CheckSessionExists(sessionNames);
                        break;
                    case 7:
                        ShowDurationStatistics(sessionDurations);
                        break;
                    case 8:
                        ShowSessionDateDetails(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 9:
                        ShowPastAndUpcomingSessions(sessionNames, sessionDates);
                        break;
                    case 10:
                        FindNextSession(sessionNames, sessionDates);
                        break;
                    case 11:
                        CompareTwoSessionDates(sessionNames, sessionDates);
                        break;
                    case 12:
                        DateTime validDate = ReadSessionDate();
                        Console.WriteLine($"Valid date entered: {validDate:yyyy-MM-dd HH:mm}");
                        break;
                    case 13:
                        SelectSessionByIndex(sessionNames);
                        break;
                    case 14:
                        TestDurationValidation();
                        break;
                    case 15:
                        Console.WriteLine(BuildReportUsingString(sessionNames, sessionDates, sessionDurations));
                        break;
                    case 16:
                        Console.WriteLine(BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations));
                        break;
                    case 0:
                        exit = true;
                        Console.WriteLine("Exiting application...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // ==================== LANGUAGE FEATURE DEMONSTRATIONS ====================

        public static void DemonstrateLanguageFeatures(string[] sessionNames, int[] sessionDurations)
        {
            Console.WriteLine("=== Executing Language Feature Demonstrations ===");
            
            // ref demonstration
            int val = 50;
            Console.WriteLine($"[ref] Value before call: {val}");
            ModifyValue(ref val);
            Console.WriteLine($"[ref] Value after call: {val}");

            // out demonstration
            string searchTarget = "C# Basics";
            if (GetSessionInfo(sessionNames, sessionDurations, searchTarget, out int index, out int duration))
            {
                Console.WriteLine($"[out] Session '{searchTarget}' found at index {index} with duration {duration} mins.");
            }
            else
            {
                Console.WriteLine($"[out] Session '{searchTarget}' not found.");
            }

            // Reference type parameter without ref demonstration
            string[] tempArray = (string[])sessionNames.Clone();
            Console.WriteLine($"[Reference Type] Element [0] before call: {tempArray[0]}");
            ModifyArrayElementWithoutRef(tempArray);
            Console.WriteLine($"[Reference Type] Element [0] after call: {tempArray[0]}");

            // params demonstration with 2, 3, and 5 arguments
            int total2 = CalculateTotalDuration(180, 240);
            int total3 = CalculateTotalDuration(180, 240, 180);
            int total5 = CalculateTotalDuration(180, 240, 180, 240, 180);
            Console.WriteLine($"[params] 2 args duration: {total2} mins | 3 args duration: {total3} mins | 5 args duration: {total5} mins");
        }

        // ==================== FUNCTIONS ====================

        // Part 2 — Display All Sessions
        public static void DisplaySessions(string[] names, DateTime[] dates, int[] durations)
        {
            for (int i = 0; i < names.Length; i++)
            {
                DisplaySessionDetails(names[i], dates[i], durations[i], i + 1);
            }
        }

        public static void DisplaySessionDetails(string name, DateTime date, int duration, int number = 0)
        {
            if (number > 0) Console.WriteLine($"{number}. {name}");
            else Console.WriteLine($"Session: {name}");

            Console.WriteLine($"   Date: {date:dd MMMM yyyy}");
            Console.WriteLine($"   Start Time: {date:hh:mm tt}");
            Console.WriteLine($"   Duration: {duration} minutes\n");
        }

        // Part 3 — Search for a Session
        public static void SearchSession(string[] names, DateTime[] dates, int[] durations)
        {
            Console.Write("Enter session name to search: ");
            string searchName = Console.ReadLine() ?? "";

            int index = Array.IndexOf(names, searchName);

            if (index != -1)
            {
                Console.WriteLine("\nSession Details:");
                DisplaySessionDetails(names[index], dates[index], durations[index]);
            }
            else
            {
                Console.WriteLine("Session not found.");
            }
        }

        // Part 4.1 — Sort Session Names
        public static void SortSessionNames(string[] names)
        {
            string[] sortedNames = new string[names.Length];
            Array.Copy(names, sortedNames, names.Length);
            Array.Sort(sortedNames);

            Console.WriteLine("Sorted Session Names (Alphabetical):");
            foreach (string name in sortedNames)
            {
                Console.WriteLine($"- {name}");
            }
        }

        // Part 4.2 — Reverse Session Names
        public static void ReverseSessionNames(string[] names)
        {
            string[] reversedNames = new string[names.Length];
            Array.Copy(names, reversedNames, names.Length);
            Array.Reverse(reversedNames);

            Console.WriteLine("Reversed Session Names:");
            foreach (string name in reversedNames)
            {
                Console.WriteLine($"- {name}");
            }
        }

        // Part 4.3 — Find Session Index
        public static void FindSessionIndex(string[] names)
        {
            Console.Write("Enter session name: ");
            string name = Console.ReadLine() ?? "";
            int index = Array.IndexOf(names, name);
            Console.WriteLine($"Index: {index}");
        }

        // Part 4.4 — Check Session Exists
        public static void CheckSessionExists(string[] names)
        {
            Console.Write("Enter session name: ");
            string name = Console.ReadLine() ?? "";
            bool exists = Array.Exists(names, element => element.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (exists)
                Console.WriteLine("Session exists.");
            else
                Console.WriteLine("Session does not exist.");
        }

        // Part 5 — Duration Analysis
        public static int GetTotalDuration(int[] durations)
        {
            int total = 0;
            for (int i = 0; i < durations.Length; i++) total += durations[i];
            return total;
        }

        public static double GetAverageDuration(int[] durations)
        {
            if (durations.Length == 0) return 0;
            return (double)GetTotalDuration(durations) / durations.Length;
        }

        public static int GetShortestDuration(int[] durations)
        {
            int min = durations[0];
            for (int i = 1; i < durations.Length; i++)
            {
                if (durations[i] < min) min = durations[i];
            }
            return min;
        }

        public static int GetLongestDuration(int[] durations)
        {
            int max = durations[0];
            for (int i = 1; i < durations.Length; i++)
            {
                if (durations[i] > max) max = durations[i];
            }
            return max;
        }

        public static void ShowDurationStatistics(int[] durations)
        {
            Console.WriteLine($"Total Duration: {GetTotalDuration(durations)} minutes");
            Console.WriteLine($"Average Duration: {GetAverageDuration(durations)} minutes");
            Console.WriteLine($"Shortest Duration: {GetShortestDuration(durations)} minutes");
            Console.WriteLine($"Longest Duration: {GetLongestDuration(durations)} minutes");

            int[] sortedDurations = new int[durations.Length];
            Array.Copy(durations, sortedDurations, durations.Length);
            Array.Sort(sortedDurations);

            Console.WriteLine("Sorted Durations (Smallest to Largest):");
            foreach (int d in sortedDurations)
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine();
        }

        // Part 7 — Reference Parameter (ref)
        public static void ModifyValue(ref int number)
        {
            number += 10;
        }

        // Part 8 — Reference Parameter with out
        public static bool GetSessionInfo(string[] names, int[] durations, string searchName, out int index, out int duration)
        {
            index = Array.IndexOf(names, searchName);
            if (index != -1)
            {
                duration = durations[index];
                return true;
            }
            index = -1;
            duration = 0;
            return false;
        }

        // Part 9 — Reference Type Parameter without ref
        public static void ModifyArrayElementWithoutRef(string[] names)
        {
            if (names.Length > 0)
            {
                names[0] = "Modified inside function";
            }
        }

        // Part 10 — Params Function
        public static int CalculateTotalDuration(params int[] durations)
        {
            int total = 0;
            for (int i = 0; i < durations.Length; i++) total += durations[i];
            return total;
        }

        // Part 11 — Session Date Details
        public static DateTime GetSessionEndTime(DateTime startTime, int durationMinutes)
        {
            return startTime.AddMinutes(durationMinutes);
        }

        public static void ShowSessionDateDetails(string[] names, DateTime[] dates, int[] durations)
        {
            Console.Write("Enter session name: ");
            string name = Console.ReadLine() ?? "";
            int index = Array.IndexOf(names, name);

            if (index != -1)
            {
                DateTime date = dates[index];
                DateTime endTime = GetSessionEndTime(date, durations[index]);

                Console.WriteLine($"Session: {names[index]}");
                Console.WriteLine($"Date: {date:dd MMMM yyyy}");
                Console.WriteLine($"Day: {date.DayOfWeek}");
                Console.WriteLine($"Year: {date.Year}");
                Console.WriteLine($"Month: {date.Month}");
                Console.WriteLine($"Day Number: {date.Day}");
                Console.WriteLine($"Start Time: {date:hh:mm tt}");
                Console.WriteLine($"Duration: {durations[index]} minutes");
                Console.WriteLine($"End Time: {endTime:hh:mm tt}");

                Console.WriteLine("\n--- Date Formatting Examples ---");
                Console.WriteLine(date.ToString("yyyy-MM-dd"));
                Console.WriteLine(date.ToString("dd/MM/yyyy"));
                Console.WriteLine(date.ToString("dd MMMM yyyy"));
                Console.WriteLine(date.ToString("dddd, dd MMMM yyyy"));
                Console.WriteLine(date.ToString("hh:mm tt"));
            }
            else
            {
                Console.WriteLine("Session not found.");
            }
        }

        // Part 12 — Date Difference
        public static void CompareTwoSessionDates(string[] names, DateTime[] dates)
        {
            Console.Write("Enter first session name: ");
            string name1 = Console.ReadLine() ?? "";
            Console.Write("Enter second session name: ");
            string name2 = Console.ReadLine() ?? "";

            int idx1 = Array.IndexOf(names, name1);
            int idx2 = Array.IndexOf(names, name2);

            if (idx1 != -1 && idx2 != -1)
            {
                TimeSpan diff = dates[idx2] - dates[idx1];
                if (diff < TimeSpan.Zero) diff = diff.Duration();

                Console.WriteLine("Difference between dates:");
                Console.WriteLine($"{diff.Days} days");
                Console.WriteLine($"{(int)diff.TotalHours} total hours");
            }
            else
            {
                Console.WriteLine("One or both sessions not found.");
            }
        }

        // Part 13 — Past and Upcoming Sessions
        public static void ShowPastAndUpcomingSessions(string[] names, DateTime[] dates)
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < names.Length; i++)
            {
                string status = dates[i] < now ? "Past" : "Upcoming";
                Console.WriteLine($"{names[i]} - {status}");
            }
        }

        // Part 14 — Find the Next Session
        public static void FindNextSession(string[] names, DateTime[] dates)
        {
            DateTime now = DateTime.Now;
            int nearestIndex = -1;
            TimeSpan smallestDiff = TimeSpan.MaxValue;

            for (int i = 0; i < dates.Length; i++)
            {
                if (dates[i] > now)
                {
                    TimeSpan diff = dates[i] - now;
                    if (diff < smallestDiff)
                    {
                        smallestDiff = diff;
                        nearestIndex = i;
                    }
                }
            }

            if (nearestIndex != -1)
            {
                Console.WriteLine("Next Session:");
                Console.WriteLine(names[nearestIndex]);
                Console.WriteLine(dates[nearestIndex].ToString("dd MMMM yyyy"));
                Console.WriteLine(dates[nearestIndex].ToString("hh:mm tt"));
                Console.WriteLine("Time Remaining:");
                Console.WriteLine($"{smallestDiff.Days} days");
                Console.WriteLine($"{smallestDiff.Hours} hours");
            }
            else
            {
                Console.WriteLine("No upcoming sessions found.");
            }
        }

        // Part 17 — Read and Validate Date Format
        public static DateTime ReadSessionDate()
        {
            DateTime date;
            while (true)
            {
                Console.Write("Enter date (yyyy-MM-dd HH:mm): ");
                string input = Console.ReadLine() ?? "";

                if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    return date;
                }
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }

        // Part 18 — Exception Handling for Menu Input
        public static int ReadMenuOption()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine() ?? "";
                    return int.Parse(input);
                }
                catch (FormatException)
                {
                    Console.Write("Invalid input. Please enter a number: ");
                }
            }
        }

        // Part 19 — Exception Handling for Index
        public static void SelectSessionByIndex(string[] names)
        {
            Console.Write("Enter session index: ");
            try
            {
                int index = int.Parse(Console.ReadLine() ?? "");
                Console.WriteLine($"Session: {names[index]}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The selected session index is out of range.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format.");
            }
        }

        // Part 20 & 21 — Throw Exception and finally
        public static void ValidateDuration(int duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentException("Duration must be greater than zero.");
            }
            Console.WriteLine("Duration accepted.");
        }

        public static void TestDurationValidation()
        {
            try
            {
                Console.Write("Enter duration: ");
                int dur = int.Parse(Console.ReadLine() ?? "");
                ValidateDuration(dur);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
            }
            finally
            {
                Console.WriteLine("Input operation finished.");
            }
        }

        // Part 22 — Build Schedule Report Using string
        public static string BuildReportUsingString(string[] names, DateTime[] dates, int[] durations)
        {
            string result = "";
            for (int i = 0; i < names.Length; i++)
            {
                result += $"{names[i]} {dates[i]:dd/MM/yyyy hh:mm tt} {durations[i]} minutes\n";
            }
            return result;
        }

        // Part 23 — Build Schedule Report Using StringBuilder
        public static string BuildReportUsingStringBuilder(string[] names, DateTime[] dates, int[] durations)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < names.Length; i++)
            {
                sb.Append(names[i])
                  .Append(" ")
                  .Append(dates[i].ToString("dd/MM/yyyy hh:mm tt"))
                  .Append(" ")
                  .Append(durations[i])
                  .Append(" minutes\n");
            }
            return sb.ToString();
        }
    }
}