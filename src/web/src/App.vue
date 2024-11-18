<script setup lang="ts">
import { onMounted, ref } from 'vue';

const message = ref('');

onMounted(async () => {
  const response = await fetch('http://localhost:5000/api/message');
  const data = await response.json();
  message.value = data.message;
});
</script>

<template>
  <main>
    <div>
      <h1>Minimal API Response</h1>
      <p>{{ message }}</p>
    </div>
  </main>
</template>

<style scoped></style>
