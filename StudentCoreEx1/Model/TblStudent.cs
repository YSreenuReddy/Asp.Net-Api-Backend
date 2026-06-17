using System;
using System.Collections.Generic;

namespace StudentCoreEx1.Model;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public int StudentAge { get; set; }

    public string StudentCourse { get; set; } = null!;
}
