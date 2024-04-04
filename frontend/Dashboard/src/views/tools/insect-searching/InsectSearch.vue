<template>
  <div>
    <div class="container-fluid">
      <div class="row mb-4">
        <div class="col-lg-12">
          <h1 class="text-center">Insect Classification Tool</h1>
          <p class="text-center">Delve into Insect Diversity: Our tool classifies insects and showcases results with captivating charts! Discover the wonders of the insect world 🐞🦋.</p>
        </div>
      </div>

      <div class="row">
        <!-- Step one -->
        <div class="card">
          <div class="card-body">
            <h3 class="card-title mb-4">Let's start easy...</h3>
            <CAlert color="warning" v-if="warning.show" closeButton> {{ warning.msg}} </CAlert>
            <DropZone :class="{ 'disabled-card': isDisabled }" class="text-center drop-area" @file="loadFile" v-slot="{ dropZoneActive }">
              <label for="file-input">
                <span v-if="dropZoneActive">
                  <span>Drop It Here</span>
                  <span class="smaller">to add it</span>
                </span>
                <span v-else>
                  <span>Drag Your File Here</span>
                  <span class="smaller">
                    or <strong><em>click here</em></strong> to select a file
                  </span>
                </span>

                <input type="file" id="file-input" multiple @change="onInputChange" />
              </label>
              <ul v-if="Object.keys(file).length > 0" class="center-list">
                <FilePreview :key="file.id" :file="file" @remove="remove" />
              </ul>

            </DropZone>
            <button @click.prevent="uploadFiles" class="upload-button center" :disabled="isDisabled">
              <CSpinner color="info" v-if="isDisabled" /> <span class="mt-4">{{loading}}</span></button>
          </div>
        </div>
        <!-- Step Two -->
        <div class="card mt-4" v-if="showChart">
          <div class="card-body">
            <h3 class="card-title mb-4">Your results...</h3>
            <CChartBar :data="chartData" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';

import useFileList from '../../../misc/file-list.js';
import DropZone from './DropZone.vue';
import FilePreview from './FilePreview.vue';
import { classifierImage } from '../../../services/search-insect';

const { file, addFiles, removeFile, getFiles } = useFileList();
let showChart = ref(false);
let resultsClassified = ref({});
let isDisabled = ref(false);
let loading = ref('Upload');
let warning = ref({});


const remove = () => {
  warning.value.msg = null;
  warning.value.show = false;
  showChart.value = false;
  removeFile()
}
const onInputChange = (e) => {
  warning.value.msg = null;
  warning.value.show = false;
  const file = Array.from(e.target.files);
  const fileName = file[0].name; 
  if (!checkFileType(fileName)) {
    warning.value.msg = "Sorry paul, only .jpeg .png .jpg file extension are allowed.";
    warning.value.show = true;
    e.target.value = null
    return;
  }
  addFiles(file);
  e.target.value = null;
};

const checkFileType = (fileName) => {
  const allowedTypes = ['jpeg', 'png', 'jpg'];
  const fileExtension = fileName.slice(fileName.lastIndexOf('.') + 1);
  if (!allowedTypes.includes(fileExtension)) return false
  return true
}

const loadFile = (file) => {
  warning.value.msg = null;
  warning.value.show = false;
  const fileName = file[0].name; 
  if (!checkFileType(fileName)) {
    warning.value.msg = "Sorry paul, only .jpeg .png .jpg file extension are allowed.";
    warning.value.show = true;
    file = {}
    return;
  }

  addFiles(file)
}

async function convertBlobUrlToFormData(blobObj) {
  try {
    const response = await fetch(blobObj.url);
    if (!response.ok) {
      throw new Error(`Failed to fetch image: ${response.status} ${response.statusText}`);
    }

    const blob = await response.blob();
    const formData = new FormData();
    const file = new File([blob], blobObj.file.name, { type: blobObj.file.type });
    formData.append('file', file);
    
    return formData;
  } catch (error) {
    console.error('Error converting Blob URL to binary:', error.message);
    throw error;
  }
}

const uploadFiles = async () => {
  try {
    if (!Object.keys(file.value).length > 0) {
      warning.value.msg = "Please select or drag a file to start searching.";
      warning.value.show = true;
      return;
    }

    warning.value.msg = null;
    warning.value.show = false;
    isDisabled.value = true;
    showChart.value = false;
    loading = 'Processing image...';

    const formData = await convertBlobUrlToFormData(file.value);
    const response = await classifierImage(formData);
    resultsClassified = JSON.parse(response.data.resultsClassified);
    isDisabled.value = false;
    showChart.value = true;
    loading = 'Upload';
  } catch (error) {
    isDisabled.value = false; 
    loading = 'Upload';
    warning.value.msg = "Ups! Something went badly wrong : " + error;    
    warning.value.show = true;       
    console.error('classifier error:', error.message);
  }
};

const chartData = () => {
  const categories = [];
  const results = [];
  for (const key in resultsClassified) {
    
    if (resultsClassified.hasOwnProperty(key)) {
      categories.push(key);
      results.push(resultsClassified[key]);
    }
  }
  return {
    labels: categories,
    datasets: [
      {
        label: 'Category coincidence',
        backgroundColor: '#f87979',
        data: results,
      },
    ],
  };
};
</script>

<style scoped lang="stylus">
.disabled-card {
  opacity: 0.5; /* Example: Reduce opacity to visually indicate disabled state */
  pointer-events: none; /* Disable mouse events on the card */
}

.center-list {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
}

.drop-area {
  border: 2px dashed #ccc;
  border-radius: 20px;
  width: 100%;
  max-width: 800px;
  margin: 0 auto;
  padding: 50px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
  transition: .2s ease;

  &[data-active=true] {
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
    background: #ffffffcc;
  }
}

label {
  font-size: 36px;
  cursor: pointer;
  display: block;

  span {
    display: block;
  }

  input[type=file]:not(:focus-visible) {
    // Visually Hidden Styles taken from Bootstrap 5
    position: absolute !important;
    width: 1px !important;
    height: 1px !important;
    padding: 0 !important;
    margin: -1px !important;
    overflow: hidden !important;
    clip: rect(0, 0, 0, 0) !important;
    white-space: nowrap !important;
    border: 0 !important;
  }

  .smaller {
    font-size: 16px;
  }
}

.image-list {
  display: flex;
  list-style: none;
  flex-wrap: wrap;
  padding: 0;
}

.upload-button {
  display: block;
  appearance: none;
  border: 0;
  border-radius: 50px;
  padding: 0.75rem 3rem;
  margin: 1rem auto;
  font-size: 1.25rem;
  font-weight: bold;
  background: #369;
  color: #fff;
  text-transform: uppercase;
}

button {
  cursor: pointer;
}
</style>