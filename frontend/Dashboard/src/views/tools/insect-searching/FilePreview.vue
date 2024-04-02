<template>
  <div :is="tag" class="file-preview">
    <button @click="removeFile" class="close-icon">&times;</button>
     <div class="image-container">
      <img :src="file.url" :alt="file.file.name" :title="file.name" />
     </div>
    <span :class="statusClass" v-text="statusText"></span>
  </div>
</template>

<script setup>
import { defineProps, defineEmits } from 'vue';

const { file, tag } = defineProps(['file', 'tag']);
const emit = defineEmits(['remove']);

const statusClass = {
  loading: 'status-indicator loading-indicator',
  true: 'status-indicator success-indicator',
  false: 'status-indicator failure-indicator',
}[file.status];

const statusText = {
  loading: 'In Progress',
  true: 'Uploaded',
  false: 'Error',
}[file.status];

const removeFile = () => {
  emit('remove', file);
};
</script>

<style scoped lang="stylus">
.file-preview {
  width: 50%;
  margin: 1rem 2.5%;
  position: relative;
  aspect-ratio: 1/1;
  overflow: hidden;

  .image-container {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 100%;
  }

  img {
    max-width: 100%;
    max-height: 100%;
    display: block;
    object-fit: contain;
  }

  img {
    width: 100%;
    height: 100%;
    display: block;
    object-fit: cover;
  }

  .close-icon, .status-indicator {
    --size: 20px;
    position: absolute;
    line-height: var(--size);
    height: var(--size);
    border-radius: var(--size);
    box-shadow: 0 0 5px currentColor;
    right: 0.25rem;
    appearance: none;
    border: 0;
    padding: 0;
  }

  .close-icon {
    width: var(--size);
    font-size: var(--size);
    background: #933;
    color: #fff;
    top: 0.25rem;
    cursor: pointer;
  }

  .status-indicator {
    font-size: calc(0.75 * var(--size));
    bottom: 0.25rem;
    padding: 0 10px;
  }

  .loading-indicator {
    animation: pulse 1.5s linear 0s infinite;
    color: #000;
  }

  .success-indicator {
    background: #6c6;
    color: #040;
  }

  .failure-indicator {
    background: #933;
    color: #fff;
  }
}

@keyframes pulse {
  0% {
    background: #fff;
  }

  50% {
    background: #ddd;
  }

  100% {
    background: #fff;
  }
}
</style>