# Academy Schedule Analyzer

* **Student Name:** Mohamed
* **Cohort:** C# Intermediate
* **Assignment:** Academy Schedule Analyzer & Benchmark Audit

---

## 📁 Repository Map & Project Structure

* **Main C# Application:** [`AcademyScheduleAnalyzer/`](file:///c:/Users/mohamed/source/repos/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer)
  * **Console Application Entry Point:** [`Program.cs`](file:///c:/Users/mohamed/source/repos/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer/Program.cs)
  * **Project Configuration:** [`AcademyScheduleAnalyzer.csproj`](file:///c:/Users/mohamed/source/repos/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer.csproj)
* **Benchmark Implementation & Results:**
  * **Benchmark Class:** [`AcademyScheduleAnalyzer/Benchmarks/StringBenchmark.cs`](file:///c:/Users/mohamed/source/repos/AcademyScheduleAnalyzer/AcademyScheduleAnalyzer/Benchmarks/StringBenchmark.cs)
  * **Benchmark Report & Analysis:** [`BENCHMARK.md`](file:///c:/Users/mohamed/source/repos/AcademyScheduleAnalyzer/BENCHMARK.md)
* **LeetCode Submissions & Evidence:**
  * **LeetCode Documentation:** [`LeetCode/README.md`](file:///c:/Users/mohamed/source/repos/AcademyScheduleAnalyzer/LeetCode/README.md)
  * **Screenshots Directory:** [`LeetCode/images/`](file:///c:/Users/mohamed/source/repos/AcademyScheduleAnalyzer/LeetCode/images)
* **LinkedIn Technical Documentation:**
  * **LinkedIn Posts Summary:** [`LinkedIn/README.md`](file:///c:/Users/mohamed/source/repos/AcademyScheduleAnalyzer/LinkedIn/README.md)

---

## 🚀 How to Run the Application

### 1. Run Interactive Console Menu Loop
To launch the 16-option interactive schedule analyzer console application:
```bash
dotnet run --project AcademyScheduleAnalyzer
```

### 2. Execute Performance Benchmarks
To run the BenchmarkDotNet suite comparing `string` concatenation vs `StringBuilder`:
```bash
dotnet run -c Release --project AcademyScheduleAnalyzer -- --benchmark
```
