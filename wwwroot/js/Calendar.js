//JavaScript for the calendar functionality

document.addEventListener('DOMContentLoaded', function () {
    var DateJumper = document.getElementById('DateJumper');
    var calendarEl = document.getElementById('calendar');
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
            end: 'dateJumper'
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

                }
            }
        }
    });
    calendar.render();
});
