using System;
using System.Runtime.InteropServices;

class Program
{
    [Flags]
    enum EXECUTION_STATE : uint
    {
        ES_SYSTEM_REQUIRED = 0x00000001,
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_CONTINUOUS = 0x80000000
    }

    [DllImport("kernel32.dll")]
    static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

    static void Main()
    {
        // Giữ hệ thống và màn hình luôn hoạt động (không sleep/không tắt màn hình)
        var result = SetThreadExecutionState(
            EXECUTION_STATE.ES_CONTINUOUS |
            EXECUTION_STATE.ES_SYSTEM_REQUIRED |
            EXECUTION_STATE.ES_DISPLAY_REQUIRED
        );

        if (result == 0)
        {
            Console.WriteLine("SetThreadExecutionState failed.");
            return;
        }

        Console.WriteLine("KeepAwake is ON. Press Enter to stop...");
        Console.ReadLine();

        // Trả về trạng thái bình thường
        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        Console.WriteLine("KeepAwake is OFF.");
    }
}