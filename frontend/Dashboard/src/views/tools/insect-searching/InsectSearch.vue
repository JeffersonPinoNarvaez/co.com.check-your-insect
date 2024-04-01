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
            <DropZone class="text-center drop-area" @file="loadFile" v-slot="{ dropZoneActive }">
              <label for="file-input">
                <span v-if="dropZoneActive">
                  <span>Drop Them Here</span>
                  <span class="smaller">to add them</span>
                </span>
                <span v-else>
                  <span>Drag Your Files Here</span>
                  <span class="smaller">
                    or <strong><em>click here</em></strong> to select files
                  </span>
                </span>

                <input type="file" id="file-input" multiple @change="onInputChange" />
              </label>
              <ul v-if="Object.keys(files).length > 0">
                <FilePreview :key="files.id" :file="files" @remove="removeFile" />
              </ul>
            </DropZone>
            <button @click.prevent="uploadFiles" class="upload-button">Upload</button>
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

const { files, addFiles, removeFile, getFiles } = useFileList();
let showChart = ref(false);
let resultsClassified = ref({});


const onInputChange = (e) => {
  const newFiles = Array.from(e.target.files);
  addFiles(newFiles);
  e.target.value = null;
};

const loadFile = (file) => {
  addFiles(file)
}

const uploadFiles = async () => {
  showChart.value = false;
  const formData = new FormData();
  formData.append('file', files.value);
  
  try {
    const response = await classifierImage(formData);
    resultsClassified = JSON.parse(response.resultsClassified);
    showChart.value = true;
  } catch (error) {
    console.error('classifier error:', error.message);
  }
};

const chartData = () => {
  const categories = [];
  const results = [];
  for (const key in resultsClassified) {
    console.log(key)
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