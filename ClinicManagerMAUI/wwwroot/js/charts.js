// charts.js - Funciones para renderizar gráficos con Chart.js

let appointmentsStatusChart = null;
let patientsPieChart = null;
let timeSlotBarChart = null;

window.renderAppointmentsStatusChart = function (data) {
    const ctx = document.getElementById('appointmentsStatusChart');
    if (!ctx) return;

    // Destruir gráfico anterior si existe
    if (appointmentsStatusChart) {
        appointmentsStatusChart.destroy();
    }

    appointmentsStatusChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: ['Completadas', 'Confirmadas', 'Pendientes', 'Canceladas'],
            datasets: [{
                data: [data.completed, data.confirmed, data.pending, data.cancelled],
                backgroundColor: [
                    'rgba(25, 135, 84, 0.8)',    // success
                    'rgba(13, 202, 240, 0.8)',   // info
                    'rgba(255, 193, 7, 0.8)',    // warning
                    'rgba(220, 53, 69, 0.8)'     // danger
                ],
                borderColor: [
                    'rgba(25, 135, 84, 1)',
                    'rgba(13, 202, 240, 1)',
                    'rgba(255, 193, 7, 1)',
                    'rgba(220, 53, 69, 1)'
                ],
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: true,
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        padding: 15,
                        font: {
                            size: 12
                        }
                    }
                },
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            const label = context.label || '';
                            const value = context.parsed || 0;
                            const total = context.dataset.data.reduce((a, b) => a + b, 0);
                            const percentage = ((value / total) * 100).toFixed(1);
                            return `${label}: ${value} (${percentage}%)`;
                        }
                    }
                }
            }
        }
    });
};

window.renderPatientsPieChart = function (data) {
    const ctx = document.getElementById('patientsPieChart');
    if (!ctx) return;

    if (patientsPieChart) {
        patientsPieChart.destroy();
    }

    patientsPieChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ['Nuevos', 'Recurrentes'],
            datasets: [{
                data: [data.newPatients, data.returningPatients],
                backgroundColor: [
                    'rgba(13, 110, 253, 0.8)',   // primary
                    'rgba(25, 135, 84, 0.8)'     // success
                ],
                borderColor: [
                    'rgba(13, 110, 253, 1)',
                    'rgba(25, 135, 84, 1)'
                ],
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: true,
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        padding: 15,
                        font: {
                            size: 12
                        }
                    }
                },
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            const label = context.label || '';
                            const value = context.parsed || 0;
                            const total = context.dataset.data.reduce((a, b) => a + b, 0);
                            const percentage = ((value / total) * 100).toFixed(1);
                            return `${label}: ${value} (${percentage}%)`;
                        }
                    }
                }
            }
        }
    });
};

window.renderTimeSlotBarChart = function (labels, data) {
    const ctx = document.getElementById('timeSlotBarChart');
    if (!ctx) return;

    if (timeSlotBarChart) {
        timeSlotBarChart.destroy();
    }

    timeSlotBarChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Cantidad de Citas',
                data: data,
                backgroundColor: 'rgba(13, 202, 240, 0.8)',
                borderColor: 'rgba(13, 202, 240, 1)',
                borderWidth: 2,
                borderRadius: 5,
                borderSkipped: false
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: true,
            plugins: {
                legend: {
                    display: false
                },
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            return `Citas: ${context.parsed.y}`;
                        }
                    }
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        stepSize: 1,
                        font: {
                            size: 11
                        }
                    },
                    grid: {
                        color: 'rgba(0, 0, 0, 0.05)'
                    }
                },
                x: {
                    ticks: {
                        font: {
                            size: 11
                        }
                    },
                    grid: {
                        display: false
                    }
                }
            }
        }
    });
};