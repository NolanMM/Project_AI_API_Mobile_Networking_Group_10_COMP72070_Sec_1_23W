import torch
import sys
from PIL import Image
from lavis.models import load_model_and_preprocess

# setup device to use
device = torch.device("cuda" if torch.cuda.is_available() else "cpu")

# load sample image
raw_image = Image.open(sys.argv[1]).convert("RGB")

# loads BLIP caption base model, with finetuned checkpoints on MSCOCO captioning dataset.
# this also loads the associated image processors
model, vis_processors, _ = load_model_and_preprocess(name="blip_caption", model_type="base_coco", is_eval=True, device=device)

# preprocess the image
# vis_processors stores image transforms for "train" and "eval" (validation / testing / inference)
image = vis_processors["eval"](raw_image).unsqueeze(0).to(device)

list_return = list()
# generate caption
list_return = model.generate({"image": image})
# ['a caption']

print(type(model.generate({"image": image})))
for i in list_return:
    print(i)

path = 'C:\\Users\\user\\Source\\Repos\\Project_AI_API_Mobile_Networking_Group_10_COMP72070_Sec_1_23W\\ImageCaptionTemp.txt'

with open(path, 'w') as f:
    f.writelines(list_return)
    f.close()