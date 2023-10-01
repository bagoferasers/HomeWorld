bl_info = {
    "name" : "Real Cloud",
    "author" : "Blender", 
    "description" : "Real Clouds is an amazing free add-on for Blender, the popular 3D software. This add-on allows users to quickly and easily create volumetric clouds with the click of a button. It is perfect for creating realistic sky scenes in any 3D project.",
    "blender" : (3, 0, 0),
    "version" : (1, 0, 0),
    "location" : "",
    "waring" : "",
    "doc_url": "", 
    "tracker_url": "", 
    "category" : "3D View" 
}


import bpy
import bpy.utils.previews

import os
import os
import os


def string_to_int(value):
    if value.isdigit():
        return int(value)
    return 0

def string_to_icon(value):
    if value in bpy.types.UILayout.bl_rna.functions["prop"].parameters["icon"].enum_items.keys():
        return bpy.types.UILayout.bl_rna.functions["prop"].parameters["icon"].enum_items[value].value
    return string_to_int(value)
    
def icon_to_string(value):
    for icon in bpy.types.UILayout.bl_rna.functions["prop"].parameters["icon"].enum_items:
        if icon.value == value:
            return icon.name
    return "NONE"
    
def enum_set_to_string(value):
    if type(value) == set:
        if len(value) > 0:
            return "[" + (", ").join(list(value)) + "]"
        return "[]"
    return value
    
def string_to_type(value, to_type, default):
    try:
        value = to_type(value)
    except:
        value = default
    return value

addon_keymaps = {}
_icons = None
real_cloud = {}


def sna_update_sna_realcloud_8A609(self, context):
    sna_updated_prop = self.sna_realcloud
    bpy.ops.wm.append(directory=os.path.join(os.path.dirname(__file__), 'assets', 'Real Cloud.blend') + r'\Object', filename=sna_updated_prop, link=False)
    for i_95C67 in range(len(bpy.context.view_layer.objects.selected)):
        if bpy.context.view_layer.objects.selected[i_95C67].select_get():
            bpy.context.view_layer.objects.active = bpy.context.view_layer.objects.selected[i_95C67]
        else:
            pass
_item_map = dict()
def make_enum_item(_id, name, descr, preview_id, uid):
    lookup = str(_id)+"\0"+str(name)+"\0"+str(descr)+"\0"+str(preview_id)+"\0"+str(uid)
    if not lookup in _item_map:
        _item_map[lookup] = (_id, name, descr, preview_id, uid)
    return _item_map[lookup]
def load_preview_icon(path):
    global _icons
    if not path in _icons:
        if os.path.exists(path):
            _icons.load(path, path, "IMAGE")
        else:
            return 0
    return _icons[path].icon_id

def sna_realcloud_enum_items(self, context):
    enum_items = [['Clouds', 'Clouds', '', load_preview_icon(os.path.join(os.path.dirname(__file__), 'assets', 'Screenshot 2023-09-01 142039.png'))]]
    return [make_enum_item(item[0], item[1], item[2], item[3], i) for i, item in enumerate(enum_items)]
class SNA_PT_REAL_CLOUD_EFD43(bpy.types.Panel):
    bl_label = 'Real Cloud'
    bl_idname = 'SNA_PT_REAL_CLOUD_EFD43'
    bl_space_type = 'VIEW_3D'
    bl_region_type = 'UI'
    bl_context = ''
    bl_category = 'RC'
    bl_order = 0
    
    
    @classmethod
    def poll(cls, context):
        return not (False)
    
    def draw_header(self, context):
        layout = self.layout
        
    def draw(self, context):
        layout = self.layout
        layout.template_icon_view(bpy.context.scene, 'sna_realcloud', show_labels=False, scale=5.0, scale_popup=5.0)
        col_DCCA8 = layout.column(heading='', align=False)
        col_DCCA8.alert = False
        col_DCCA8.enabled = True
        col_DCCA8.use_property_split = False
        col_DCCA8.use_property_decorate = False
        col_DCCA8.scale_x = 1.0
        col_DCCA8.scale_y = 1.0
        col_DCCA8.alignment = 'Expand'.upper()
        col_DCCA8.prop(bpy.context.view_layer.objects.active.active_material.node_tree.nodes['Group'].inputs[1], 'default_value', text='Clouds Scale', icon_value=0, emboss=True)
        col_DCCA8.prop(bpy.context.view_layer.objects.active.active_material.node_tree.nodes['Group'].inputs[2], 'default_value', text='Clouds Density', icon_value=0, emboss=True)
        col_DCCA8.prop(bpy.context.view_layer.objects.active.active_material.node_tree.nodes['Group'].inputs[3], 'default_value', text='Clouds Density 2', icon_value=0, emboss=True)
        col_DCCA8.prop(bpy.context.view_layer.objects.active.active_material.node_tree.nodes['Group'].inputs[4], 'default_value', text='Clouds Density 3', icon_value=0, emboss=True)
        col_DCCA8.prop(bpy.context.view_layer.objects.active.active_material.node_tree.nodes['Group'].inputs[5], 'default_value', text='Clouds Fac', icon_value=0, emboss=True)
        col_DCCA8.prop(bpy.context.view_layer.objects.active.active_material.node_tree.nodes['Group'].inputs[0], 'default_value', text='Clouds Color', icon_value=0, emboss=True)
        col_DCCA8.prop(bpy.context.view_layer.objects.active.active_material.node_tree.nodes['Group'].inputs[6], 'default_value', text='Clouds A', icon_value=0, emboss=True)
        col_DCCA8.prop(bpy.context.view_layer.objects.active.active_material.node_tree.nodes['Group'].inputs[9], 'default_value', text='Clouds A Color', icon_value=0, emboss=True)
        




def register():
    
    global _icons
    _icons = bpy.utils.previews.new()
    bpy.types.Scene.sna_realcloud = bpy.props.EnumProperty(name='realcloud', description='', items=sna_realcloud_enum_items, update=sna_update_sna_realcloud_8A609)
    
    
    bpy.utils.register_class(SNA_PT_REAL_CLOUD_EFD43)

def unregister():
    
    global _icons
    bpy.utils.previews.remove(_icons)
    
    wm = bpy.context.window_manager
    kc = wm.keyconfigs.addon
    for km, kmi in addon_keymaps.values():
        km.keymap_items.remove(kmi)
    addon_keymaps.clear()
    del bpy.types.Scene.sna_realcloud
    
    
    bpy.utils.unregister_class(SNA_PT_REAL_CLOUD_EFD43)

