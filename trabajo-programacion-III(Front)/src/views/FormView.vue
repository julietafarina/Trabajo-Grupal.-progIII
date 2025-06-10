<script setup>
import { ref } from 'vue'
import axios from 'axios'
let datosgastos = ref({
  fecha: '',
  descripcion: '',
  monto: '',
  nombrecomercio: '',
})
const mensaje = ref('')
const mensajedescripcion = ref('')
const mensajefecha = ref('')
const mensajenombre = ref('')

const EnviarDatos = async () => {
  if (!datosgastos.value.monto || datosgastos.value.monto <= 0) {
    mensaje.value = '⚠️ El monto es obligatorio y debe ser mayor a 0.'
  } else {
    mensaje.value = ''
  }
  if (
    !datosgastos.value.descripcion ||
    datosgastos.value.descripcion.length < 3 ||
    datosgastos.value.descripcion.length > 250
  ) {
    mensajedescripcion.value = '⚠️ La descripción debe tener entre 3 y 250 caracteres.'
  } else {
    mensajedescripcion.value = ''
  }
  if (datosgastos.value.fecha == '' || new Date(datosgastos.value.fecha) > new Date()) {
    mensajefecha.value = '⚠️ La fecha es obligatoria y no debe ser futura.'
  } else {
    mensajefecha.value = ''
  }
  if (
    !datosgastos.value.nombrecomercio ||
    datosgastos.value.nombrecomercio.trim().length === 0 ||
    datosgastos.value.nombrecomercio.length > 250
  ) {
    mensajenombre.value =
      '⚠️ El nombre de comercio es obligatorio y debe tener hasta 250 caracteres.'
  } else {
    mensajenombre.value = ''
  }

  try {
    const response = await axios.post('http://localhost:5231/api/Gastos', datosgastos.value)
    console.log('Datos enviados exitosamente', response.data)
    if (response.status === 200 || response.status === 201) {
      datosgastos.value = {
        fecha: '',
        descripcion: '',
        monto: '',
        nombrecomercio: '',
      }
    }
  } catch (error) {
    console.log(error.response.data)
    console.error('Error al enviar de datos', error)
  }
}
</script>

<template>
  <h1>Formulario</h1>
  <div class="container">
    <h2>Gastos</h2>

    <form id="gastoForm" @submit.prevent="EnviarDatos">
      <label for="monto">Monto: </label>

      <input type="number" id="monto" v-model="datosgastos.monto" />
      <p>{{ mensaje }}</p>

      <label for="descripcion">Descripción:</label>
      <input type="text" id="descripcion" v-model="datosgastos.descripcion" />
      <p>{{ mensajedescripcion }}</p>

      <label for="fecha">Fecha:</label>
      <input type="date" id="fecha" v-model="datosgastos.fecha" />
      <p>{{ mensajefecha }}</p>

      <label for="nombrecomercio">Nombre de comercio:</label>
      <input type="text" id="nombreComercio" v-model="datosgastos.nombrecomercio" />
      <p>{{ mensajenombre }}</p>

      <button type="submit" value="Guardar">Registrar Gasto</button>
    </form>
    <p id="mensaje"></p>
  </div>
</template>

<style>
body {
  font-family: Arial, sans-serif;
  background-color: #355d69;
  text-align: left;
}

.container {
  max-width: 70%;
  margin: 5% auto;
  padding: 30px;
  background: #b1c6ca;
  border-radius: 8px;
  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
}

h1 {
  font-style: italic;
  color: aliceblue;
  text-align: left;
}

.container h2 {
  text-align: center;
  font-style: italic;
  border-bottom: 3px solid white;
  padding-bottom: 10px;
  width: 100%;
}

.linea {
  width: 100%;
  height: 3px;
  background-color: white;
  margin-top: 20px;
}

form {
  display: flex;
  flex-direction: column;
}

input {
  margin-bottom: 10px;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

button {
  background-color: #384854;
  color: white;
  padding: 10px;
  border: none;
  cursor: pointer;
}

button:hover {
  background-color: #5e8783;
}
</style>
