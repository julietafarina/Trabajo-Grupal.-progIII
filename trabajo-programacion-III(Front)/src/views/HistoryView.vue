<script setup>
import { ref } from 'vue'
import axios from 'axios'
const datosgastos = ref([])

async function CargarDatos() {
  try {
    const response = await axios.get('http://localhost:5231/api/Gastos')
    datosgastos.value = response.data
  } catch (error) {
    console.error('Error con inicializacion de datos', error)
  }
}
CargarDatos()
</script>

<template>
  <h1 class="titulo">Historial de Gastos</h1>

  <div class="container">
    <table>
      <thead>
        <tr>
          <th>Fecha</th>
          <th>Descripción</th>
          <th>Monto</th>
          <th>Comercio</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="Gastos in datosgastos" :key="Gastos.Id">
          <td>{{ Gastos.fecha }}</td>
          <td>{{ Gastos.descripcion }}</td>
          <td>${{ Gastos.monto }}</td>
          <td>{{ Gastos.nombrecomercio }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style>
body {
  font-family: Arial, sans-serif;
  background: #355d69;
  color: white;
  text-align: center;
  padding: 20px;
}

.titulo {
  text-align: left;
  margin-left: 20px;
  font-size: 24px;
  font-style: italic;
}

.container {
  max-width: 1000px;
  margin: 5% auto;
  background: rgba(255, 255, 255, 0.2);
  padding: 30px;
  border-radius: 10px;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.2);
  backdrop-filter: blur(6px);
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 10px;
}

th,
td {
  padding: 12px;
  border-bottom: 1px solid white;
}

th {
  text-align: left;
  font-weight: bold;
}

td {
  text-align: left;
}
</style>
