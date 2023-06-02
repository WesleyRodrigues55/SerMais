document.addEventListener('DOMContentLoaded', function () {

    var url = new URL(window.location.href);
    var pathnameParts = url.pathname.split("/");
    var ultimoParametro = pathnameParts[pathnameParts.length - 1];

    var calendarEl = document.getElementById('calendar');
    var today = new Date();
    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            left: 'prevYear,prev,next,nextYear today',
            center: 'title',
            right: 'dayGridMonth,dayGridWeek,dayGridDay'
        },
        locale: 'pt-br',
        initialDate: today,
        navLinks: true,
        dayMaxEvents: true,
        events: function (fetchInfo, successCallback, failureCallback) {
            fetch(`https://localhost:7235/api/agendamento/GetConsultasProfissional/${ultimoParametro}`)
                .then(function (response) {
                    return response.json();
                })
                .then(function (data) {
                    var events = [];
                    data.forEach(function (item) {
                        var start = moment(item.iD_AGENDA_PROFISSIONAL.dia + ' ' + item.iD_AGENDA_PROFISSIONAL.horA_START, 'YYYY/MM/DD HH:mm').toDate();
                        var end = moment(item.iD_AGENDA_PROFISSIONAL.dia + ' ' + item.iD_AGENDA_PROFISSIONAL.horA_END, 'YYYY/MM/DD HH:mm').toDate();

                        var event = {
                            id: item.id,
                            description: item.queixa,
                            title: item.iD_AGENDA_PROFISSIONAL.ativo == 1 ? "- Disponível" : "- Consulta",
                            start: start,
                            end: end,
                            data: moment(item.dia).format('DD/MM/YYYY'),
                            backgroundColor: item.iD_AGENDA_PROFISSIONAL.ativo == 1 ? "green" : "yellow",
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

        //eventClick: function (info) {
        //    var event = info.event;
        //    var title = event.title;
        //    var start = event.start.toLocaleTimeString('pt-BR', { hour: '2-digit', minute: '2-digit' });
        //    var end = event.end.toLocaleTimeString('pt-BR', { hour: '2-digit', minute: '2-digit' });
        //    var description = event.extendedProps.description;
        //    var agendamentoId = event.id;

        //    document.getElementById('eventTitle').textContent = 'Título: ' + title;
        //    document.getElementById('eventStart').textContent = 'Início: ' + start;
        //    document.getElementById('eventEnd').textContent = 'Fim: ' + end;
        //    document.getElementById('eventDescription').textContent = 'Queixa: ' + description;

        //    alert('Informações do evento:\n\nTítulo: ' + title + '\nInício: ' + start + '\nFim: ' + end + '\nDescrição: ' + description);
        //    //$('#eventModal').data('agendamento-id', agendamentoId);
        //    //$('#eventModal').modal('show');
        //}

        eventClick: function (info) {
            // Aqui você pode exibir um diálogo/modal com as informações do evento
            var event = info.event;
            var title = event.title;
            var start = event.start.toLocaleTimeString('pt-BR', { hour: '2-digit', minute: '2-digit' });
            var end = event.end.toLocaleTimeString('pt-BR', { hour: '2-digit', minute: '2-digit' });
            var description = event.extendedProps.description;

            // Exemplo de exibição das informações em um diálogo simples
            alert('Informações do evento:\n\nTítulo: ' + title + '\nInício: ' + start + '\nFim: ' + end + '\nDescrição: ' + description);
        }

    });

    calendar.render();
});