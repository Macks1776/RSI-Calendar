//JavaScript for the calendar functionality

document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var DateJumper = new bootstrap.Modal(document.getElementById('DateJumper'), focus);
    var BranchPicker = new bootstrap.Modal(document.getElementById('BranchJumper'), focus);
    var calendar = new FullCalendar.Calendar(calendarEl, {
        eventSources: [
            {
                url: '/calendar/ReqEventJson',
                extraParams: {
                    branch: 'default'
                },
                color: 'red',
                textColor: 'white'
            },
            {
                url: '/calendar/EduEventJson',
                extraParams: {
                    branch: 'default'
                },
                color: 'blue',
                textColor: 'white'
            },
            {
                url: '/calendar/FunEventJson',
                extraParams: {
                    branch: 'default'
                },
                color: 'green',
                textColor: 'white'
            },
            {
                url: '/calendar/FamEventJson',
                extraParams: {
                    branch: 'default'
                },
                color: 'yellow',
                textColor: 'black'
            }
        ],
        initalView: 'dayGridMonth',
        navLinks: true,
        height: "auto",
        headerToolbar: {
            start: 'title',
            end: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
        },
        footerToolbar: {
            start: 'prev,next today',
            end: 'branchPicker dateJumper'
        },
        eventClick: function (info) {
            var eventObj = info.event;
            if (eventObj.url) {
                window.open(eventObj.url);
                info.jsEvent.preventDefault();
            } else {
                alert('Clicked Event: ' + eventObj.title);
            }
        },
        customButtons: {
            dateJumper: {
                text: 'Go To Date',
                click: function () {
                    DateJumper.show();
                }
            },
            branchPicker: {
                text: 'Change Branch',
                click: function () {
                    BranchPicker.show();
                }
            }
        }
    });
    calendar.render();

    document.getElementById('SubmitJump').addEventListener('click', function () {
        let month = $("#MonthPicker option:selected").val();
        let year = $("#YearPicker option:selected").val();
        DateJumper.hide();

        var date = year + '-' + month + '-01';

        calendar.gotoDate(date);
        calendar.changeView('dayGridMonth');

    });

    
});



