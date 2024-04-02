import { ref } from 'vue'

export default function () {
	let file = ref([])

	function addFiles(items) {
		let newUploadableFiles = [...items].map((item) => new UploadableFile(item))
		file.value = Object.assign({}, newUploadableFiles[0])
	}

	function removeFile() {
		file.value = {}
	}

	return { file, addFiles, removeFile }
}

class UploadableFile {
	constructor(file) {
		this.file = file
		this.id = `${file.name}-${file.size}-${file.lastModified}-${file.type}`
		this.url = URL.createObjectURL(file)
		this.status = null
	}
}