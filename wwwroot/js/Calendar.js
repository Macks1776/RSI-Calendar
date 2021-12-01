//JavaScript for the calendar functionality

document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var DateJumper = new bootstrap.Modal(document.getElementById('DateJumper'), focus);
    var BranchPicker = new bootstrap.Modal(document.getElementById('BranchJumper'), focus);
    var calendar = new FullCalendar.Calendar(calendarEl, {
        eventSources: [
            {
                url: '/calendar/getrequiredevents',
                color: 'red',
                textColor: 'white'
            },
            {
                url: '/calendar/geteducationevents',
                color: 'blue',
                textColor: 'white'
            },
            {
                url: '/calendar/getfunevents',
                color: 'green',
                textColor: 'white'
            },
            {
                url: '/calendar/getfamilyevents',
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
            start: 'prevYear,prev,next,nextYear today',
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

    document.getElementById('SubmitBranch').addEventListener('click', function () {
        let branch = $("#BranchPicker option:selected").val();
        DateJumper.hide();

        calendar = new FullCalendar.Calendar(calendarEl, {
            eventSources: [
                {
                    url: '/calendar/getrequiredevents/' + branch,
                    color: 'red',
                    textColor: 'white'
                },
                {
                    url: '/calendar/geteducationevents' + branch,
                    color: 'blue',
                    textColor: 'white'
                },
                {
                    url: '/calendar/getfunevents' + branch,
                    color: 'green',
                    textColor: 'white'
                },
                {
                    url: '/calendar/getfamilyevents' + branch,
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
                start: 'prevYear,prev,next,nextYear today',
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
    });
});



