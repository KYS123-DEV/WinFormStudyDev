using KYS.NET.BL.Common;
using System.Text;

namespace KYS.NET.STUDY.Utils
{
   public class FileLogger : IDisposable
  {
    private readonly FileStream _fileStream;
    private readonly StreamWriter _streamWriter;

    internal FileLogger(string fileName)
    {
      _fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.Read);
      _streamWriter = new StreamWriter(_fileStream, Encoding.UTF8);
    }

    /// <summary>
    /// 로그 파일 내부에 기록하기
    /// </summary>
    /// <param name="msg"></param>
    internal void WriteLog(string msg)
    {
      _streamWriter.WriteLine($"[{DateTime.Now:f}] (+) {SessionManager.CurrentSession?.UserId} ] Task : {msg}");
    }

    /// <summary>
    /// 자원 해제
    /// </summary>
    public void Dispose()
    {
      _streamWriter.Dispose();
      _fileStream.Dispose();
    }
  }

  /// <summary>
  /// 파일 Log 호출 클래스
  /// </summary>
  public class CallFileLooger
  {
    public static void CallWriteLog(string msg)
    {
      //로그인 시간, 로그인한 사용자ID, (INSERT, UPDATE, DELETE)기록
      string path = @"C:\TempLog\";
      if (!Directory.Exists(path)) Directory.CreateDirectory(path);

      string fullPath = Path.Combine(path, $"{DateTime.Now.ToString("yyyy-MM-dd")}.log");

      FileLogger fileLogger = new FileLogger(fullPath);
      fileLogger.WriteLog(msg);

      fileLogger.Dispose();
    }
  }
}
