import { ref } from 'vue'

export default function () {
	let files = ref([])

	function addFiles(file) {
		let newUploadableFiles = [...file].map((file) => new UploadableFile(file)).filter((file) => !fileExists(file.id))
		files.value = Object.assign({}, newUploadableFiles[0])
	}

	function fileExists(otherId) {
		if (Object.keys(files.value).length > 0)
			return files.value.some(({ id }) => id === otherId)
	}

	function removeFile() {
		files.value = {}
	}

	return { files, addFiles, removeFile }
}

class UploadableFile {
	constructor(file) {
		this.file = file
		this.id = `${file.name}-${file.size}-${file.lastModified}-${file.type}`
		this.url = URL.createObjectURL(file)
		this.status = null
	}
}