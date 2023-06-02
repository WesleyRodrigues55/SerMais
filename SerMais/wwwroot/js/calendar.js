document.addEventListener('DOMContentLoaded', function () {

    var url = new URL(window.location.href);
    var pathnameParts = url.pathname.split("/");
    var penultimoParametro = pathnameParts[pathnameParts.length - 2];


    var calendarEl = document.getElementById('calendar');
    var today = new Date();
    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            left: 'prev,next,today',
            center: 'title',
            right: 'dayGridMonth,dayGridWeek,dayGridDay'
        },
        locale: 'pt-br',
        initialDate: today,
        navLinks: true,
        dayMaxEvents: true,
        events: function (fetchInfo, successCallback, failureCallback) {
            fetch(`https://localhost:7235/api/agendamento/GetConsultas/${penultimoParametro}`)
                .then(function (response) {
                    return response.json();
                })
                .then(function (data) {
                    var events = [];
                    data.forEach(function (item) {
                        var start = moment(item.dia + ' ' + item.horA_START, 'YYYY/MM/DD HH:mm').toDate();
                        var end = moment(item.dia + ' ' + item.horA_END, 'YYYY/MM/DD HH:mm').toDate();

                        var event = {
                            id: item.ID,
                            title: item.ativo == 1 ? "- Disponível" : "- Consulta",
                            start: start,
                            end: end,
                            backgroundColor: item.ativo == 1 ? "green" : "yellow",
                        };
                        events.push(event);
                    });
                    console.log(data)
                    successCallback(events);
                })
                .catch(function (error) {
                    failureCallback(error);
                });
        },


    });

    calendar.render();
});