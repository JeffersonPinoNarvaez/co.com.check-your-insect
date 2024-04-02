<template>
  <div :data-active="active" @dragenter.prevent="setActive" @dragover.prevent="setActive" @dragleave.prevent="setInactive" @drop.prevent="onDrop">
    <slot :dropZoneActive="active"></slot>
  </div>
</template>

<script setup>
import { ref, defineEmits, onMounted, onUnmounted } from 'vue';

const emit = defineEmits(['file']);
const events = ['dragenter', 'dragover', 'dragleave', 'drop'];

const active = ref(false);
let inActiveTimeout = null;

const setActive = () => {
  active.value = true;
  clearTimeout(inActiveTimeout);
};

const setInactive = () => {
  inActiveTimeout = setTimeout(() => {
    active.value = false;
  }, 50);
};

const onDrop = (e) => {
  setInactive();
  const droppedFiles = [...e.dataTransfer.files];
  if (droppedFiles.length > 0) {
    emit('file', droppedFiles);
  }
};

const preventDefaults = (e) => {
  e.preventDefault();
};

onMounted(() => {
  events.forEach((eventName) => {
    document.body.addEventListener(eventName, preventDefaults);
  });
});

onUnmounted(() => {
  events.forEach((eventName) => {
    document.body.removeEventListener(eventName, preventDefaults);
  });
});
</script>