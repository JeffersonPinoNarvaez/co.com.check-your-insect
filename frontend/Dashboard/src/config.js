export const configurations = {
    services: {
        host: 'http://localhost:8080',
        url: 'http://localhost:7089/api/',
        headers: {
            content_type: 'application/json; charset=utf-8; multipart/form-data',
        }
    },
    app: {
        categories: [
            {
                name: 'Bees',
                coverPicture: 'assets/images/categories/bee.png',
                facts: [
                    'Bees are important pollinators, helping to fertilize plants and crops.',
                    'They communicate through intricate dances known as the waggle dance.',
                    'A beehive can hold thousands of bees, including workers, drones, and a queen.',
                    'Bees produce honey as a food source for the colony, storing it in honeycombs.',
                    'Some bee species are solitary, while others live in highly organized colonies.'
                ]
            },
            {
                name: 'Beetles',
                coverPicture: 'assets/images/categories/beetle.png',
                facts: [
                    'Beetles make up the largest group of insects, with over 350,000 species identified.',
                    'They come in a wide range of shapes, sizes, and colors, from tiny to large and dull to vibrant.',
                    'Some beetles have fascinating defense mechanisms, such as emitting noxious chemicals or playing dead.',
                    'Beetles can be found in almost every habitat on Earth, including land, freshwater, and saltwater environments.',
                    'Certain species of beetles, like fireflies, can produce light through a process called bioluminescence.'
                ]
            },
            {
                name: 'Butterflies',
                coverPicture: 'assets/images/categories/butterfly.png',
                facts: [
                    'Butterflies taste with their feet, using chemoreceptors to detect the presence of food.',
                    'Their wings are covered in tiny scales, which give them their vibrant colors and patterns.',
                    'Butterflies undergo a complete metamorphosis, starting as eggs, then becoming larvae (caterpillars), pupae (chrysalises), and finally emerging as adult butterflies.',
                    'Many butterflies exhibit complex behaviors, such as migration, mating dances, and territorial displays.',
                    'Butterflies play a crucial role in ecosystems as pollinators and as prey for other animals.'
                ]
            },
            {
                name: 'Cicadas',
                coverPicture: 'assets/images/categories/cicadas.png',
                facts: [
                    'Cicadas are known for their loud, buzzing calls, which can reach up to 120 decibels.',
                    'They spend most of their lives underground as nymphs, feeding on plant roots.',
                    'Cicadas emerge from the ground in massive numbers, called broods, usually every 13 or 17 years depending on the species.',
                    'Adult cicadas have short lifespans, typically living for only a few weeks to a few months.',
                    'Their mating calls are species-specific and play a vital role in attracting mates and establishing territories.'
                ]
            },
            {
                name: 'Dragonflies',
                coverPicture: 'assets/images/categories/dragonflies.png',
                facts: [
                    'Dragonflies have been around for over 300 million years, making them one of the oldest insect groups on Earth.',
                    'They are expert hunters, capable of catching prey in mid-air with their sharp mandibles.',
                    'Dragonflies have excellent vision, with large compound eyes that provide them with a 360-degree field of view.',
                    'Their unique flying abilities allow them to hover, fly backward, and change direction rapidly.',
                    'Some species of dragonflies migrate long distances, traveling thousands of miles between breeding and feeding grounds.'
                ]
            },
            {
                name: 'Grasshopper',
                coverPicture: 'assets/images/categories/grasshopper.png',
                facts: [
                    'Grasshoppers are known for their incredible jumping abilities, with some species capable of leaping up to 20 times their body length.',
                    'They produce sound by rubbing their hind legs against their wings, creating a distinctive chirping noise.',
                    'Grasshoppers are herbivores, feeding primarily on grasses and other vegetation.',
                    'Some species of grasshoppers can change color to blend in with their surroundings, providing camouflage from predators.',
                    'They have specialized mouthparts for chewing and consuming plant material.'
                ]
            },
            {
                name: 'Moth',
                coverPicture: 'assets/images/categories/moth.png',
                facts: [
                    'Moths are nocturnal insects, typically active at night and resting during the day.',
                    'They are attracted to light sources, which can sometimes lead them to be considered pests in urban areas.',
                    'Moths exhibit a wide range of colors and patterns, from drab browns to vibrant yellows and reds.',
                    'Some species of moths are important pollinators, helping to fertilize flowers and crops.',
                    'They have sensitive antennae that allow them to detect pheromones released by potential mates.'
                ]
            },
            {
                name: 'Scorpion',
                coverPicture: 'assets/images/categories/scorpion.png',
                facts: [
                    'Scorpions are ancient arachnids, with fossils dating back millions of years.',
                    'They are equipped with venomous stingers located at the end of their tails, which they use to immobilize prey and defend themselves.',
                    'Scorpions are capable of surviving in harsh environments, including deserts and tropical forests.',
                    'Some species of scorpions fluoresce under ultraviolet light, emitting a greenish-blue glow.',
                    'They are skilled hunters, using their keen sense of smell and vibration-sensing organs to locate prey.'
                ]
            },
            {
                name: 'Snail',
                coverPicture: 'assets/images/categories/snail.png',
                facts: [
                    'Snails are gastropod mollusks, characterized by their spiral shells and slow-moving behavior.',
                    'They have a unique muscular foot that they use to glide over surfaces, leaving behind a trail of mucus.',
                    'Snails are hermaphrodites, possessing both male and female reproductive organs.',
                    'Some species of snails hibernate during periods of cold weather, sealing themselves inside their shells to conserve moisture.',
                    'They play important roles in ecosystems as both decomposers and food sources for other animals.'
                ]
            },
            {
                name: 'Spider',
                coverPicture: 'assets/images/categories/spider.png',
                facts: [
                    'Spiders are arachnids, not insects, and are characterized by their eight legs and ability to produce silk.',
                    'They use silk to construct webs for catching prey, as well as for building shelters and egg sacs.',
                    'Spiders inject venom into their prey through specialized fangs, which helps to immobilize and digest their meals.',
                    'Many species of spiders are skilled predators, hunting down insects and other small creatures.',
                    'Some spiders, like the black widow and brown recluse, possess venom that can be harmful to humans.'
                ]
            },
        ],
    }
}