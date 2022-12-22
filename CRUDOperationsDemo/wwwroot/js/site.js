// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.localStorage.setItem("type", 1);

function onAdminDash(x) {
    window.location.href = "/Admin/Index";
}

function onStudentDash(x) {
    window.location.href = "/Student/Detail";
}

function onTeacherDash(x) {
    window.location.href = "/Teacher/Detail";
}

function onDeleteSubject(x) {

    const subject = {
        "Id": x.id,
    };

    if (subject.Id) {
        $.ajax({
            type: 'POST',
            url: '/Subject/Delete',
            data: JSON.stringify(subject),
            success: function (data) {
                window.location.reload();

            },
            error: function (err) {
                alert("Data Error");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    }
}
function onDeleteInstructor(x) {

    var id = $("#instTeacher").find('option:selected').attr('id');
    const subject = {
        "SubjectId": x.id,
        "TeacherId": id
    };

    console.log(subject);
    
    if (subject.SubjectId) {
        $.ajax({
            type: 'POST',
            url: '/Instructor/Delete',
            data: JSON.stringify(subject),
            success: function (data) {
                window.location.reload();
            },
            error: function (err) {
                alert("Data Error");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    }
}
function onPresent(x) {
    window.localStorage.setItem(x.id, 1);
}
function onLate(x) {
    window.localStorage.setItem(x.id, 2);
}
function onAbsent(x) {
    window.localStorage.setItem(x.id, 4);
}
function onStudentAbsense(x) {

    var inputId = x.id + "100";
    var itemId = x.id + "10";

    var date = new Date($("#dateTeacher").text());

    const absense = {
        "ClientId":1,
        "StudentId": x.id,
        "Subject": $("#absenseSubject").text(),
        "Teacher": $("#absenseTeacher").text(),
        "Date": date,
        "AbsenseType": window.localStorage.getItem(itemId),
        "Note": $("#" + inputId).val(),
    };

    console.log(absense);
    if (absense.StudentId && absense.AbsenseType && absense.Note) {
        $.ajax({
            type: 'POST',
            url: '/StudentAbsense/CreateAbsense/',
            data: JSON.stringify(absense),
            success: function (data) {
                console.log("success");
            },
            error: function (err) {
                alert("Data Error");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    }
    else {
        alert("InputData error");
    }
}
function onDeleteEnroll(x) {

    const enroll = {
        "Id": x.id,
    };

    if (enroll.Id) {
        $.ajax({
            type: 'POST',
            url: '/Enrollment/Delete',
            data: JSON.stringify(enroll),
            success: function (data) {
                window.location.reload();
            },
            error: function (err) {
                alert("Data Error");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    }
}
function onDeleteTeacher(x) {
    const student = {
        "Id": x.id,
        "FirstName": "",
        "LastName": "",
        "Email": "",
        "Title": "Teacher",
    };

    if (student.Id) {
        console.log("Success");
        $.ajax({
            type: 'POST',
            url: '/Teacher/Delete',
            data: JSON.stringify(student),
            success: function (data) {
                console.log("Success");
                window.location.reload();
            },
            error: function (err) {
                alert("Data Error");
            },
            contentType: "application/json",
            dataType: 'json'
        });
    }
}
function onDeleteStudent(x) {

    console.log(x.id);

    const student = {
            "Id": x.id,
            "FirstName": "",
            "LastName": "",
            "Email": "",
            "Title": "Student",
        };

    if (student.Id) {
            $.ajax({
                type: 'POST',
                url: '/Student/Delete',
                data: JSON.stringify(student),
                success: function (data) {
                    window.location.reload();

                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
}

$(document).ready(function () {
    var checked_subject_ids = [];
    var checked_teacher_ids = [];
    
    $(".form-check-input123").change(function (e) {
        if (e.target.checked) {
            checked_subject_ids.push(e.target.id);
            checked_teacher_ids.push(e.target.value);
        } else {
            checked_subject_ids = checked_subject_ids.filter(function (i) { return i != e.target.id });
            checked_teacher_ids = checked_teacher_ids.filter(function (i) { return i != e.target.value });
        }
    })

    $("#teacherSubmit").click(function () {

        var date = new Date($("#dateTeacher").text());

        var sendData = [];

        $('.teacherNote').map(function (index) {
            // this callback function will be called once for each matching element

            const absense = $("input[name='" + this.id + "']:checked").val();
            const temp = {
                "ClientId": 1,
                "StudentId": parseInt(this.id),
                "Subject": $("#absenseSubject").text(),
                "Teacher": $("#absenseTeacher").text(),
                "Date": date,
                "Note": this.value,
                "AbsenseType": parseInt(absense),
            };
            sendData.push(temp);
        });

        console.log("SendData", sendData);
        if (sendData.length > 0) {
            $.ajax({
                type: 'POST',
                url: '/StudentAbsense/CreateAbsense/',
                data: JSON.stringify(sendData),
                success: function (data) {
                    alert("Attendance has been recorded");  
                    window.location.href = "/Login/Index";
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })

    $("#btnCreate").click(function () {
        const student = {
            "FirstName": $("#stdFirst").val(),
            "LastName": $("#stdLast").val(),
            "Email": $("#schoolEmail").val(),
            "Title": "Student",
        };

        if (student.FirstName && student.LastName && student.Email) {
            $.ajax({
                type: 'POST',
                url: '/Student/CreateStudent',
                data: JSON.stringify(student),
                success: function (data) {
                    window.location.reload();
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })

    $("#btnBack").click(function () {
        window.location.href = "/";
    })

    $("#btnTakeAttendance").click(function () {
        var subject = $("#attendance").find('option:selected').attr('id');
        var newDate = new Date($('#attendanceDate').val());

        console.log($(".attName").attr('id'));
        const attend = {
            "teacherId": $(".attName").attr('id'),
            "teacherName": $(".attName").text(),
            "subjectId": subject,
            "period": $("#attPeriod").val(),
            "date": newDate
        }

        console.log("attendance", attend);
        if (attend.date != null && attend.period != null && attend.subjectId != null) {
            $.ajax({
                type: 'POST',
                url: '/Teacher/TakeAttendance',
                data: JSON.stringify(attend),
                success: function (data) {
                    window.location.href = "/Teacher/Detail"
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })

    $("#btnAddInstructor").click(function () {

        var id1 = $("#instTeacher").find('option:selected').attr('id');
        var id2 = $("#instSubject").find('option:selected').attr('id');

        const instructor = {
            "TeacherId": id1,
            "SubjectId": id2
        };

        console.log($("#instSubject").val);
        console.log("instructor", instructor);
        if (instructor.TeacherId && instructor.SubjectId) {
            $.ajax({
                type: 'POST',
                url: '/Instructor/Add',
                data: JSON.stringify(instructor),
                success: function (data) {
                    window.location.reload();
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })

    $("#addAbsense").click(function () {

        console.log("addAbsense");
        console.log(document.getElementsByClassName("inputAddNote"));

    });

    $("#btnAddnewStudent").click(function () {

        var newStudent = {
            "firstName": $("#newFirstName").val(),
            "lastName": $("#newLastName").val(),
            "schoolEmail": $("#newSchoolEmail").val(),
            "subjectIds": checked_subject_ids,
            "teacherIds": checked_teacher_ids
        }

        console.log(newStudent);
        if (newStudent.subjectIds && newStudent.subjectIds.length && newStudent.firstName && newStudent.lastName && newStudent.teacherIds && newStudent.teacherIds.length)
        {
            $.ajax({
                type: 'POST',
                url: '/NewStudent/Add',
                data: JSON.stringify(newStudent),
                success: function (data) {
                    alert("New student has been added"); 
                    windows.location.reload();
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Data Error");
        }
    })

    $("#btnCreateNewSemester").click(function () {

        const semester = {
            "Name": $("#semesterName").val(),
            "FromDate": $("#semesterFromDate").val(),
            "EndDate": $("#semesterEndDate").val(),
        };


        if (semester.Name && semester.FromDate && semester.EndDate) {
            $.ajax({
                type: 'POST',
                url: '/Semester/Create',
                data: JSON.stringify(semester),
                success: function (data) {
                    window.location.reload();

                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })

    $("#btnSubjetCreate").click(function () {

        const subject = {
            "Name": $("#subjectName").val(),
            "PeriodCount": $("#periodCount").val()
        };


        if (subject.Name && subject.PeriodCount) {
            $.ajax({
                type: 'POST',
                url: '/Subject/Create',
                data: JSON.stringify(subject),
                success: function (data) {
                    window.location.reload();

                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })
   
    $("#btnCreateTeacher").click(function () {

        const teacher = {
            "FirstName": $("#tFirstName").val(),
            "LastName": $("#tLastName").val(),
            "Email": $("#tEmail").val(),
            "Title": "teacher",
        };

        if (teacher.FirstName && teacher.LastName && teacher.Email) {
            $.ajax({
                type: 'POST',
                url: '/Teacher/Create',
                data: JSON.stringify(teacher),
                success: function (data) {
                    window.location.reload();

                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })

    $("#eSubject").change(function ()
    {
        var id = $(this).children(":selected").attr("id");
        var teacherId = $("#eTeacher").children(":selected").attr('id');

        const enroll = {
            "subjectName": $("#eSubject").val(),
            "teacherId": teacherId,
            "teacherName" :$("#eTeacehr").val(),
        };

        console.log(enroll);
        if (id != null) {
            $.ajax({
                type: 'POST',
                url: '/Enrollment/AccessSubject',
                data: JSON.stringify(enroll),
                success: function (data) {
                    window.location.reload();
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })

    $("#instTeacher").change(function () {
        var id = $(this).children(":selected").attr("id");

        const inst = {
            "teacherId": id
        };

        if (id != null) {
            $.ajax({
                type: 'POST',
                url: '/Instructor/AccessTeacher',
                data: JSON.stringify(inst),
                success: function (data) {
                    window.location.reload();
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })

    $("#eTeacher").change(function () {
        var id = $(this).children(":selected").attr("id");

        const enroll = {
            "teacherId": id
        };

        if (id != null) {
            $.ajax({
                type: 'POST',
                url: '/Enrollment/Access',
                data: JSON.stringify(enroll),
                success: function (data) {
                    window.location.reload();
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })

    $("#btnCreateEnroll").click(function ()
    {
        var teacherId = $("#eTeacher").children(":selected").attr('id');

        const enroll = {
            "Teacher": $("#eTeacher").val(),
            "Subject": $("#eSubject").val(),
            "Student": $("#eStudent").val(),
        };

        const enrollData = {
            "subjectName": $("#eSubject").val(),
            "teacherId": teacherId,
            "teacherName": $("#eTeacehr").val(),
            "enroll": enroll,
        };

        if (enroll.Teacher && enroll.Subject && enroll.Student) {
            $.ajax({
                type: 'POST',
                url: '/Enrollment/Create',
                data: JSON.stringify(enrollData),
                success: function (data) {
                    window.location.reload();

                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
        else {
            alert("Input Error");
        }
    })

    $("#btnRecordSave").click(function () {

        var sendData = [];
        var data = [];
        var types = [];
        $('.inputAddNote').map(function (index) {
            // this callback function will be called once for each matching element
            var text = this.value;
            if (text == undefined)
                text = this.innerText;

            const temp = {
                "Id": this.id,
                "note": text
            }

            data.push(temp);
        });

        $('.itemTypes option:selected').map(function (index) {
            types.push(this.id);
        });

        for (var i = 0; i < data.length; i++) {
            const temp = {
                "Id": data[i].Id,
                "note": data[i].note,
                "type": types[i]
            }

            sendData.push(temp);
        }
        console.log("data", sendData);

            $.ajax({
                type: 'POST',
                url: '/RecordLog/SaveRecord',
                data: JSON.stringify(sendData),
                success: function (data) {
                    window.location.reload();
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });

    })

    $("#imgTeacher").click(function () {
        window.location.href = "/Teacher/Edit";
    })

    $('#recordChange').change(function () {
        var string = $('#recordChange').val();
        var date = new Date(string);

        if (date.getDay != null && date.getMonth != null && date.getFullYear != null) {
            $.ajax({
                type: 'POST',
                url: '/RecordLog/ChangeDate',
                data: JSON.stringify(date),
                success: function (data) {
                    window.location.reload();
                },
                error: function (err) {
                    alert("Data Error");
                },
                contentType: "application/json",
                dataType: 'json'
            });
        }
    })

    $('#achrayusChange').change(function () {
        var strAchrayus = [];

        $('.student_email').map(function (index) {
            strAchrayus.push(this.id);
        });

        $('.semester_name').map(function (index) {
            strAchrayus.push(this.id);
        });

        $('#achrayusChange').map(function (index) {
            strAchrayus.push($("#achrayusChange").val());
        });

        $.ajax({
            type: 'POST',
            url: '/Admin/ChangeAchrayus',
            data: JSON.stringify(strAchrayus),
            success: function (data) {
                window.location.reload();
            },
            contentType: "application/json",
            dataType: 'json'
        });
    })

    $('#semesterItems').change(function () {
        var semesterItems = [];

        $('#semesterItems option:selected').map(function (index) {
            semesterItems.push(this.id);
        });

        $('.student_email').map(function (index) {
            semesterItems.push(this.id);
        });

        $.ajax({
            type: 'POST',
            url: '/Student/ChangeSemester',
            data: JSON.stringify(semesterItems),
            success: function (data) {
                window.location.reload();
            },
            contentType: "application/json",
            dataType: 'json'
        });
    })

    $('#semesterAdminItems').change(function () {
        var semesterItems = [];

        $('#semesterAdminItems option:selected').map(function (index) {
            semesterItems.push(this.id);
        });

        $('.student_email').map(function (index) {
            semesterItems.push(this.id);
        });

        $.ajax({
            type: 'POST',
            url: '/Admin/ChangeSemester',
            data: JSON.stringify(semesterItems),
            success: function (data) {
                window.location.reload();
            },
            contentType: "application/json",
            dataType: 'json'
        });
    })

    $("#imgStudent").click(function () {
        window.location.href = "/Student/Index";
    })

    $("#imgSubject").click(function () {
        window.location.href = "/Subject/Index";
    })

    $("#imgInstruction").click(function () {
        window.location.href = "/Instructor/Index"
    })

    $("#imgNewStudent").click(function () {
        window.location.href = "/NewStudent/Index";
    })

    $("#imgClass").click(function () {
        window.location.href = "/Enrollment/Index";
    })

    $("#recordLog").click(function () {
        window.location.href = "/RecordLog/Index";
    })

    $("#studentAccess").click(function () {

        window.location.href = "/Admin/Access";
    })

    $("#newSemester").click(function () {
        window.location.href = "/Semester/Index";
    })

})
