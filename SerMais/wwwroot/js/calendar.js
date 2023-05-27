document.addEventListener('DOMContentLoaded', function () {

    var url = new URL(window.location.href);
    var pathnameParts = url.pathname.split("/");
    var penultimoParametro = pathnameParts[pathnameParts.length - 2];

    var calendarEl = document.getElementById('calendar');
    var today = new Date();
    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            left: 'prevYear,prev,next,nextYear today',
            center: 'title',
            right: 'dayGridMonth,dayGridWeek,dayGridDay'
        },
        initialDate: today,
        navLinks: true,
        dayMaxEvents: true,
        events: function (fetchInfo, successCallback, failureCallback) {
            fetch(`https://localhost:7235/api/agendamento/${penultimoParametro}`)
                .then(function (response) {
                    return response.json();
                })
                .then(function (data) {
                    var events = [];
                    data.forEach(function (item) {
                        var event = {
                            id: item.ID,
                            title: "Consulta",
                            start: item.datA_START,
                            end: item.datA_END,
                            // Outros campos personalizados, se necessário
                            // description: item.status,

                        };
                        events.push(event);
                    });
                    console.log(data)
                    successCallback(events);
                })
                .catch(function (error) {
                    failureCallback(error);
                });
        }
    });

    calendar.render();
});